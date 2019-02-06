using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MonsterGear
{
    // From L.B at Stack Overflow: https://stackoverflow.com/questions/24106986/json-net-force-serialization-of-all-private-fields-and-all-fields-in-sub-classe
    class MyContractResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                            .Select(p => base.CreateProperty(p, memberSerialization))
                            .Union(type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                            .Select(f => base.CreateProperty(f, memberSerialization)))
                            .ToList();
            props.ForEach(p => { p.Writable = true; p.Readable = true; });
            return props;
        }
    }

    class MonsterGear
    {
        [DllImport("monsterloop.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "FindArmors")]
        private static extern int FindArmors(int[] reqsAsInt, int rsize, int weaponSlots);

        [DllImport("monsterloop.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "TransferData")]
        private static unsafe extern void TransferData(MonsterloopData data, byte* results);
        
        private static JsonSerializerSettings SETTINGS = new JsonSerializerSettings() { ContractResolver = new MyContractResolver() };
        public  static SkillId[]              skills { get; private set; }
        public  static int                    MAX_RESULTS = 128;
        private static MonsterGear           _singleton = null;

        public  ArmorPiece[][] allPieces { get; private set; }
        public  Charm[]        allCharms { get; private set; }
        private byte[]         Results { get; set; }
        private int           _numberOfResults;
        private List<Skill>   _reqs;
        private Slots         _weaponSlots;
        /* Pointer to data array for c++ */
        private IntPtr         pPieces;
        private IntPtr         pCharms;
        private IntPtr         pResults;

        private MonsterGear()
        {
            parseSkills("skills.json");
            parsePieces("pieces.json");
            parseCharms("charms.json");
            buildDataForDll(); // Will call TransferData()
        }

        public static MonsterGear GetInstance()
        {
            if (_singleton == null)
            {
                _singleton = new MonsterGear();
            }
            return _singleton;
        }

        private void parseSkills(string filename)
        {
            string json = null;
            try
            {
                using (StreamReader r = new StreamReader(filename))
                {
                    json = r.ReadToEnd();
                }
            }
            catch (Exception ex) when ( ex is FileNotFoundException || ex is DirectoryNotFoundException || ex is IOException)
            {
                throw new Exception("Problem loading file skills.json. Make sure the file is in the program's directory.");
            }
            catch (OutOfMemoryException)
            {
                throw new Exception("Out of memory while parsing skills.json");
            }

            skills = JsonConvert.DeserializeObject<SkillId[]>(json, SETTINGS);

            if (skills == null || skills.Length == 0)
            {
                throw new Exception("Malformed skills.json");
            }
            foreach (SkillId s in skills)
            {
                if (s.id <= 0)
                {
                    throw new Exception("Error parsing skills.json: a skill id must be > 0");
                }
            }
        }

        private void parsePieces(string filename)
        {
            string json = null;
            try
            {
                using (StreamReader r = new StreamReader(filename))
                {
                    json = r.ReadToEnd();
                }
            }
            catch (Exception ex) when (ex is FileNotFoundException || ex is DirectoryNotFoundException || ex is IOException)
            {
                throw new Exception("Problem loading file pieces.json. Make sure the file is in the program's directory.");
            }
            catch (OutOfMemoryException)
            {
                throw new Exception("Out of memory while parsing pîeces.json");
            }

            allPieces = JsonConvert.DeserializeObject<ArmorPiece[][]>(json, SETTINGS);
            if (allPieces == null || allPieces.Length != 5)
            {
                throw new Exception("Malformed pieces.json");
            }
        }

        private void parseCharms(string filename)
        {
            string json = null;
            try
            {
                using (StreamReader r = new StreamReader(filename))
                {
                    json = r.ReadToEnd();
                }
            }
            catch (Exception ex) when (ex is FileNotFoundException || ex is DirectoryNotFoundException || ex is IOException)
            {
                throw new Exception("Problem loading file charms.json. Make sure the file is in the program's directory.");
            }
            catch (OutOfMemoryException)
            {
                throw new Exception("Out of memory while parsing charms.json");
            }

            allCharms = JsonConvert.DeserializeObject<Charm[]>(json, SETTINGS);
            if (allCharms == null)
            {
                throw new Exception("Malformed charms.json");
            }
        }

        public static SkillId GetSkillId(int id)
        {
            // Quick hack since skills should already be numbered from 1 to whatever
            if (id > 0 && skills[id - 1].id == id) return skills[id - 1];

            int n = skills.Length;
            while (n --> 0)
            {
                if (skills[n].id == id)
                {
                    return skills[n];
                }
            }
            throw new Exception("No skill found with id " + id + ". Check pieces.json.");
        }

        // Stores all charms and pieces in a memory region the dll can read.
        // Allocates a region of memory where the dll can write down the results.
        private unsafe void buildDataForDll()
        {
            // Put the pieces in memory using a format suitable for c++ (using BasicPiece)
            BasicPiece[] _all = new BasicPiece[allPieces[0].Length + allPieces[1].Length + allPieces[2].Length + allPieces[3].Length + allPieces[4].Length];
            var handle = GCHandle.Alloc(_all, GCHandleType.Pinned); // Won't be released since the dll needs it until the whole thing shuts down.
            pPieces = handle.AddrOfPinnedObject();
            int n = 0;
            for (int i = 0; i < allPieces.Length; ++i)
            {
                for (int j = 0; j < allPieces[i].Length; ++j)
                {
                    ArmorPiece piece = allPieces[i][j];
                    BasicPiece p;
                    p.s1 = (piece.skill1 == null) ? 0 : piece.skill1.skillId.id;
                    p.r1 = (piece.skill1 == null) ? 0 : piece.skill1.rank;
                    p.s2 = (piece.skill2 == null) ? 0 : piece.skill2.skillId.id;
                    p.r2 = (piece.skill2 == null) ? 0 : piece.skill2.rank;
                    p.gem = piece.slots.AsInt();
                    _all[n++] = p;
                }
            }

            // Put the charms in memory using a format suitable for c++ (using BasicCharm)
            BasicCharm[] _allCharms = new BasicCharm[allCharms.Length];
            var handleCharm = GCHandle.Alloc(_allCharms, GCHandleType.Pinned);
            pCharms = handleCharm.AddrOfPinnedObject();
            for (int i = 0; i < allCharms.Length; ++i)
            {
                BasicCharm p;
                p.s1 = (byte)allCharms[i].skill1.skillId.id;
                p.r1 = (byte)allCharms[i].skill1.rank;
                p.s2 = (allCharms[i].skill2 == null) ? (byte)0 : (byte)allCharms[i].skill2.skillId.id;
                p.r2 = (allCharms[i].skill2 == null) ? (byte)0 : (byte)allCharms[i].skill2.rank;
                _allCharms[i] = p;
            }

            // Allocates an array for storing results
            Results = new byte[6 * MonsterGear.MAX_RESULTS];
            var resHandle = GCHandle.Alloc(Results, GCHandleType.Pinned);
            pResults = resHandle.AddrOfPinnedObject();

            // Prepare the parameters for calling TransferData
            MonsterloopData data = new MonsterloopData();
            data.maxResults = MonsterGear.MAX_RESULTS;
            data.nCharms    = allCharms.Length;
            data.nHelms     = allPieces[0].Length;
            data.nChests    = allPieces[1].Length;
            data.nGloves    = allPieces[2].Length;
            data.nWaists    = allPieces[3].Length;
            data.nLegs      = allPieces[4].Length;
            data.charms     = (BasicCharm*)pCharms;
            data.pieces     = (BasicPiece*)pPieces;
            
            // Give everything to the dll
            TransferData(data, (byte*)pResults);
        }

        // Takes the user request (skills and weapon slots) and call the dll to find the results.
        // Note: these parameters are saved so that we can compute the bonus score and needed gems later on.
        public int findArmors(List<Skill> reqs, Slots weaponSlots)
        {
            // Save request for giving meaningful results
            _reqs = reqs;
            _weaponSlots = weaponSlots;

            // Prepare data for dll call
            int[] reqsAsInt = reqs.Select(t => t.ToReq()).ToArray();
            _numberOfResults = FindArmors(reqsAsInt, reqsAsInt.Length, weaponSlots.AsInt());
            return _numberOfResults;
        }

        // To be called after findArmors have been successfully called!
        // This will give the list of ArmorSet found by the previous call to findArmors()
        // Not very elegant, but I'm too lazy to rewrite it :)
        public List<ArmorSet> GetResults()
        {
            List<ArmorSet> res = new List<ArmorSet>();
            int n = 0;
            int Count = _numberOfResults;
            while (Count --> 0)
            {
                res.Add(new ArmorSet(
                    allCharms[Results[n++]],
                    allPieces[0][Results[n++]],
                    allPieces[1][Results[n++]],
                    allPieces[2][Results[n++]],
                    allPieces[3][Results[n++]],
                    allPieces[4][Results[n++]],
                    _reqs,
                    _weaponSlots)
                );
            }
            return res;
        }
    }


}

