using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mage
{
    [Flags]
    public enum Weakness : ushort
    {
        None = 0,
        Beam = 1,
        Bomb = 2,
        Missile = 4,
        Super = 8,
        Power = 16,
        Speed = 32,
        SpeedGround = 64,
        Screw = 128,
        BombChain = 4096
    }

    public static class TweakData
    {
        //zm, mf use
        public static int ElevatorRoomPairsOffset { get; private set; }
        public static int NumTanksPerAreaOffset { get; private set; }
        public static int TankIncreaseAmountsOffset { get; private set; }
        //zm use
        public static int BlockWeaknessesOffset { get; private set; }
        public static int HatchBehaviorsOffset { get; private set; }
        public static int MapIconsOffset { get; private set; }
        public static int ChozoStatueHintsOffset { get; private set; }
        public static int ChozoHintChecksOffset { get; private set; }
        public static int ChozoHintTriggerEventsOffset { get; private set; }
        public static int HatchFlashOffset { get; private set; }
        //fusion use
        public static int SuitDamageReductionPercentOffset { get; private set; }
        public static int DimLightingEventsOffset { get; private set; }
        public static int NavRoomHatchLockEventsOffset { get; private set; }
        public static int EventLocationAndNavInfoOffset { get; private set; }
        public static int NavRoomLocationsOffset { get; private set; }
        public static int MonologueEventsOffset { get; private set; }
        public static int SecurityUnlockEventsOffset { get; private set; }
        public static int NavigationTargetsOffset { get; private set; }

        public static List<string> Difficulty { get; private set; }
        public static List<string> BreakableBlocks { get; private set; }
        public static List<string> Events { get; private set; }
        public static List<string> CheckType { get; private set; }
        public static List<string> BeamBomb { get; private set; }
        public static List<string> SuitMisc { get; private set; }
        public static List<string> MapIcon { get; private set; }
        public static Dictionary<byte, string> StatueIcon { get; private set; }

        public static List<string> SubEvent {  get; private set; }
        public static List<string> EventType { get; private set; }
        public static List<string> TargetArea { get; private set; }
        public static List<string> TargetDirection { get; private set; }

        public static void GetData()
        {
            //string[] tweakInfo = File.ReadAllLines(@".\tweak.txt");
            string[] tweakInfo = Version.TweakInfo;
            //Dictionary<string, string> dataPart = new Dictionary<string, string>();
            Dictionary<string, ValueTuple<int, int>> dataPart = new Dictionary<string, ValueTuple<int,int >>();
            string type = "";
            int start =0, end =0;
            for (int i = 0; i < tweakInfo.Length; i++)
            {
                string line = tweakInfo[i];
                if (line.Contains('['))
                {
                    start = i + 1;
                    type = line.Substring(1,line.Length - 2);
                }
                if (line == "" || i == tweakInfo.Length - 1) 
                {
                    end = i != tweakInfo.Length - 1 ? i : tweakInfo.Length;
                }
                if (type != "" && start != 0 && end != 0)
                {
                    //dataPart.Add(type, start + "&" + end);
                    dataPart.Add(type, (start, end));
                    start = 0;
                    end = 0;
                }
            }
            foreach (var pair in dataPart)
            {
                //int[] range = pair.Value.Split('&').Select(int.Parse).ToArray();
                switch (pair.Key)
                {
                    case "Offset":
                        for (int i = pair.Value.Item1; i < pair.Value.Item2; i++)
                        {
                            string[] line = tweakInfo[i].Split('=');
                            Parse(line[0], line[1]);
                        }
                        break;
                    case "Difficulty":
                        Difficulty = new List<string>();
                        for (int i = pair.Value.Item1; i < pair.Value.Item2; i++) Difficulty.Add(tweakInfo[i]);
                        break;
                    case "BreakableBlock":
                        BreakableBlocks = new List<string>();
                        for (int i = pair.Value.Item1; i < pair.Value.Item2; i++) BreakableBlocks.Add(tweakInfo[i]);
                        break;
                    case "Event":
                        Events = new List<string>();
                        for (int i = pair.Value.Item1; i < pair.Value.Item2; i++) Events.Add(Hex.ToString(i) + " - " + tweakInfo[i]);
                        break;
                    case "CheckType":
                        CheckType = new List<string>();
                        for (int i = pair.Value.Item1; i < pair.Value.Item2; i++) CheckType.Add(tweakInfo[i]);
                        break;
                    case "BeamBomb":
                        BeamBomb = new List<string>();
                        for (int i = pair.Value.Item1; i < pair.Value.Item2; i++) BeamBomb.Add(tweakInfo[i]);
                        break;
                    case "SuitMisc":
                        SuitMisc = new List<string>();
                        for (int i = pair.Value.Item1; i < pair.Value.Item2; i++) SuitMisc.Add(tweakInfo[i]);
                        break;
                    case "MapIcon":
                        MapIcon = new List<string>();
                        for (int i = pair.Value.Item1; i < pair.Value.Item2; i++) MapIcon.Add(tweakInfo[i]);
                        break;
                    case "StatueIcon":
                        StatueIcon = new Dictionary<byte, string>();
                        for (int i = pair.Value.Item1; i < pair.Value.Item2; i++)
                        {
                            string[] statueIcon = tweakInfo[i].Split(',');
                            StatueIcon.Add(Convert.ToByte(statueIcon[0],16), statueIcon[1]);
                        }
                        break;
                    case "SubEvent":
                        SubEvent = new List<string>();
                        for(int i = pair.Value.Item1; i < pair.Value.Item2; i++) SubEvent.Add(tweakInfo[i]);
                        break;
                    case "EventType":
                        EventType = new List<string>();
                        for (int i = pair.Value.Item1; i < pair.Value.Item2; i++) EventType.Add(tweakInfo[i]);
                        break;
                    case "TargetArea":
                        TargetArea = new List<string>();
                        for (int i = pair.Value.Item1; i < pair.Value.Item2; i++) TargetArea.Add(tweakInfo[i]);
                        break;
                    case "TargetDirection":
                        TargetDirection = new List<string>();
                        for (int i = pair.Value.Item1; i < pair.Value.Item2; i++) TargetDirection.Add(tweakInfo[i]);
                        break;
                    default: break;
                }
            }
        }

        private static void Parse(string name, string value)
        {
            var info = typeof(TweakData).GetProperty(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            if (info == null) { return; }

            if (info.PropertyType == typeof(byte))
            {
                byte b = Convert.ToByte(value, 16);
                info.SetValue(null, b, null);
            }
            else if (info.PropertyType == typeof(int))
            {
                int i = Convert.ToInt32(value, 16);
                info.SetValue(null, i, null);
            }
            else if (info.PropertyType == typeof(byte[]))
            {
                string[] items = value.Split(',');
                byte[] values = new byte[items.Length];
                for (int i = 0; i < items.Length; i++)
                {
                    values[i] = Convert.ToByte(items[i], 16);
                }
                info.SetValue(null, values, null);
            }
            else if (info.PropertyType == typeof(string))
            {
                info.SetValue(null, value, null);
            }
            else if (info.PropertyType == typeof(string[]))
            {
                string[] items = value.Split(',');
                info.SetValue(null, items, null);
            }
            else if (info.PropertyType == typeof(DateTime))
            {
                DateTime dt = DateTime.Parse(value);
                info.SetValue(null, dt, null);
            }
        }
    }

    public class Tank
    {
        private byte energy;
        private byte missile;
        private byte super;
        private byte power;

        private readonly int offset;

        public string Area { get; }
        public string Difficulty { get; }

        public Tank(ByteStream stream, int index, bool isIncrease)
        {
            if (isIncrease) Difficulty = TweakData.Difficulty[index];
            //else if (index == Version.AreaNames.Length) Area = "Total"; //total of tanks
            else if (index == 7) Area = "Total"; //total of tanks
            else Area = Version.AreaNames[index];

            offset = isIncrease ? TweakData.TankIncreaseAmountsOffset : TweakData.NumTanksPerAreaOffset;
            offset += index * (Version.IsMF ? 3 : 4);
            energy = stream.Read8(offset);
            missile = stream.Read8(offset + 1);
            //fusion have no super tanks
            super = Version.IsMF ? (byte)0 : stream.Read8(offset + 2);
            power = Version.IsMF ? stream.Read8(offset + 2) : stream.Read8(offset + 3);
        }

        //private void GetData(ByteStream stream, int index, bool isIncrease)
        //{
        //    offset = isIncrease ? TweakData.TankIncreaseAmountsOffset : TweakData.NumTanksPerAreaOffset;
        //    offset += index * (Version.IsMF ? 3 : 4);
        //    energy = stream.Read8(offset);
        //    missile = stream.Read8(offset + 1);
        //    //fusion have no super tanks
        //    super = Version.IsMF ? (byte)0 : stream.Read8(offset + 2);
        //    power = Version.IsMF ? stream.Read8(offset + 2) : stream.Read8(offset + 3);
        //}

        public void Write(ByteStream stream, int index, bool isIncrease)
        {
            int offset = isIncrease ? TweakData.TankIncreaseAmountsOffset : TweakData.NumTanksPerAreaOffset;
            offset += index * (Version.IsMF ? 3 : 4);
            stream.Write8(offset, energy);
            stream.Write8(offset + 1, missile);
            stream.Write8(offset + 2, Version.IsMF ? power : super);
            if (!Version.IsMF) stream.Write8(offset + 3, power);
        }

        public void Write(ByteStream stream)
        {
            stream.Write8(offset, energy);
            stream.Write8(offset + 1, missile);
            stream.Write8(offset + 2, Version.IsMF ? power : super);
            if (!Version.IsMF) stream.Write8(offset + 3, power);
        }

        public string Energy
        {
            get => Hex.ToString(energy);
            set => energy = Hex.ToByte(value);
        }
        public string Missile
        {
            get => Hex.ToString(missile);
            set => missile = Hex.ToByte(value);
        }
        public string Super
        {
            get => Hex.ToString(super);
            set => super = Hex.ToByte(value);
        }
        public string Power
        {
            get => Hex.ToString(power);
            //set { if (Hex.ToByte(value) < 16) power = Hex.ToByte(value); }
            set => power = Hex.ToByte(value);
        }
    }

    public class ElevatorPair
    {
        private byte area1;
        private byte room1;
        private byte x1;
        private byte y1;
        private byte area2;
        private byte room2;
        private byte x2;
        private byte y2;

        private readonly int offset;

        public ElevatorPair(ByteStream stream, int index)
        {
            offset = TweakData.ElevatorRoomPairsOffset;
            if(Version.IsMF)
            {//x y only for zm 
                offset += 4 * index;
                area1 = stream.Read8(offset);
                room1 = stream.Read8(offset + 1);
                area2 = stream.Read8(offset + 2);
                room2 = stream.Read8(offset + 3);
            }
            else
            {
                offset += 8 * index;
                area1 = stream.Read8(offset);
                room1 = stream.Read8(offset + 1);
                x1 = stream.Read8(offset + 2);
                y1 = stream.Read8(offset + 3);
                area2 = stream.Read8(offset + 4);
                room2 = stream.Read8(offset + 5);
                x2 = stream.Read8(offset + 6);
                y2 = stream.Read8(offset + 7);
            }
        }

        //public void Write(ByteStream stream, int index)
        //{
        //    int offset = TweakData.ElevatorRoomPairsOffset;
        //    offset += 8 * index;
        //    stream.Write8(offset, area1);
        //    stream.Write8(offset + 1, room1);
        //    stream.Write8(offset + 2, x1);
        //    stream.Write8(offset + 3, y1);
        //    stream.Write8(offset + 4, area2);
        //    stream.Write8(offset + 5, room2);
        //    stream.Write8(offset + 6, x2);
        //    stream.Write8(offset + 7, y2);
        //}

        public void Write(ByteStream stream)
        {
            if(Version.IsMF)
            {
                stream.Write8(offset, area1);
                stream.Write8(offset + 1, room1);
                stream.Write8(offset + 2, area2);
                stream.Write8(offset + 3, room2);
            }
            else
            {
                stream.Write8(offset, area1);
                stream.Write8(offset + 1, room1);
                stream.Write8(offset + 2, x1);
                stream.Write8(offset + 3, y1);
                stream.Write8(offset + 4, area2);
                stream.Write8(offset + 5, room2);
                stream.Write8(offset + 6, x2);
                stream.Write8(offset + 7, y2);
            }
        }

        public string Area1
        {
            get => Version.AreaNames[area1];
            set => area1 = (byte)Version.AreaNames.ToList().IndexOf(value);
        }

        public string Room1
        {
            get => Hex.ToString(room1);
            set => room1 = Hex.ToByte(value);
        }

        public string X1
        {
            get { return Hex.ToString(x1); }
            set => x1 = Hex.ToByte(value);
        }

        public string Y1
        {
            get => Hex.ToString(y1); 
            set => y1 = Hex.ToByte(value);
        }

        public string Area2
        {
            get => Version.AreaNames[area2];
            set => area2 = (byte)Version.AreaNames.ToList().IndexOf(value);
        }

        public string Room2
        {
            get => Hex.ToString(room2);
            set => room2 = Hex.ToByte(value);
        }

        public string X2
        {
            get { return Hex.ToString(x2); }
            set => x2 = Hex.ToByte(value);
        }

        public string Y2
        {
            get => Hex.ToString(y2);
            set => y2 = Hex.ToByte(value);
        }

        public string  Coordinate1
        {
            get => Hex.ToString(x1) + ", " + Hex.ToString(y1);
            set
            {
                value = value.Replace('，', ',');
                string[] xy = Regex.Replace(value, "\\s", "").Split(',');
                x1 = Hex.ToByte(xy[0]);
                y1 = Hex.ToByte(xy[1]);
            }
        }

        public string Coordinate2
        {
            get => Hex.ToString(x2) + ", " + Hex.ToString(y2);
            set
            {
                value = value.Replace('，', ',');
                string[] xy = Regex.Replace(value, "\\s", "").Split(',');
                x2 = Hex.ToByte(xy[0]);
                y2 = Hex.ToByte(xy[1]);
            }
        }
    }

    public class Hatch
    {
        private byte weakness;
        private ushort hits;

        private readonly int offset;

        public Hatch(ByteStream bs, int index)
        {
            //skip none and locked
            offset = TweakData.HatchBehaviorsOffset + 8;
            offset = offset + index * 4;
            weakness = bs.Read8(offset);
            hits = bs.Read16(offset + 2);
        }

        public void Write(ByteStream bs, int index)
        {
            //skip none and locked
            int offset = TweakData.HatchBehaviorsOffset + 8;
            offset = offset + index * 4;
            bs.Write8(offset, weakness);
            bs.Write16(offset + 2, hits);
        }

        public void Write(ByteStream bs)
        {
            bs.Write8(offset, weakness);
            bs.Write16(offset + 2, hits);
        }

        public Weakness Weakness
        {
            get => (Weakness)weakness;
            set => weakness = (byte)value;
        }

        //public string Hits
        //{
        //    get => Hex.ToString(hits);
        //    set => hits = Hex.ToUshort(value);
        //}

        public ushort Hits
        {
            get => hits;
            set => hits = value;
        }
    }

    public class BreakBlock
    {
        private ushort weakness;

        private readonly int offset;

        public BreakBlock(ByteStream stream, int index)
        {
            offset = TweakData.BlockWeaknessesOffset + index * 2;
            weakness = stream.Read16(offset);
        }

        public void Write(ByteStream stream)
        {
            stream.Write16(offset, weakness);
        }

        public Weakness Weakness
        {
            get => (Weakness)weakness;
            set => weakness = (ushort)value;
        }
    }

    public class MapIcon
    {
        private byte iconEvent;
        private byte iconType;
        private byte x;
        private byte y;
        private byte pixelOffset;

        private readonly int offset;

        public string IconEvent
        {
            get => TweakData.Events[iconEvent];
            set => iconEvent = (byte)TweakData.Events.IndexOf(value);
        }
        public string IconType
        {
            get => TweakData.MapIcon[iconType];
            set => iconType = (byte)TweakData.MapIcon.IndexOf(value);
        }
        public string X
        {
            get => Hex.ToString(x);
            set => x = Hex.ToByte(value);
        }
        public string Y
        {
            get => Hex.ToString(y);
            set => y = Hex.ToByte(value);
        }
        public string PixelOffset
        {
            get => Hex.ToString(pixelOffset);
            set => pixelOffset = Hex.ToByte(value);
        }

        public MapIcon(ByteStream bs, int index)
        {
            offset = TweakData.MapIconsOffset + index * 5;
            iconEvent = bs.Read8(offset);
            iconType = bs.Read8(offset + 1);
            x = bs.Read8(offset + 2);
            y = bs.Read8(offset + 3);
            pixelOffset = bs.Read8(offset + 4);
        }

        public void Write(ByteStream bs)
        {
            bs.Write8(offset, iconEvent);
            bs.Write8(offset + 1, iconType);
            bs.Write8(offset + 2, x);
            bs.Write8(offset + 3, y);
            bs.Write8(offset + 4, pixelOffset);
        }
    }

    public class Statue
    {
        private byte area;
        private byte startX;
        private byte endX;
        private byte startY;
        private byte endY;
        private byte startIcon;
        private byte tragetArea;
        private byte targetX;
        private byte tragetY;
        private byte endIcon;
        //check
        private byte type;
        private byte equipEvent;
        private byte triggerEvent;

        private void GetStatue(ByteStream bs, int offset)
        {
            area = bs.Read8(offset);
            startX = bs.Read8(offset + 1);
            endX = bs.Read8(offset + 2);
            startY = bs.Read8(offset + 3);
            endY = bs.Read8(offset + 4);
            startIcon = bs.Read8(offset + 5);
            tragetArea = bs.Read8(offset + 6);
            targetX = bs.Read8(offset + 7);
            tragetY = bs.Read8(offset + 8);
            endIcon = bs.Read8(offset + 9);
        }
        private void GetCheck(ByteStream stream, int index)
        {
            int offset = TweakData.ChozoHintChecksOffset + 0x2 * index;
            type = stream.Read8(offset);
            equipEvent = stream.Read8(offset + 1);
            triggerEvent = stream.Read8(TweakData.ChozoHintTriggerEventsOffset + index);
        }

        public Statue(ByteStream stream, int index)
        {
            int offset = TweakData.ChozoStatueHintsOffset + index * 0xC;
            GetStatue(stream, offset);
            GetCheck(stream, index);
        }

        public void Write(ByteStream stream, int index)
        {
            int offset = TweakData.ChozoStatueHintsOffset + index * 0xC;
            WriteStatue(stream, offset);
            WriteCheck(stream, index);
        }

        public void WriteStatue(ByteStream stream, int offset)
        {
            stream.Write8(offset, area);
            stream.Write8(offset + 1, startX);
            stream.Write8(offset + 2, endX);
            stream.Write8(offset + 3, startY);
            stream.Write8(offset + 4, endY);
            stream.Write8(offset + 5, startIcon);
            stream.Write8(offset + 6, tragetArea);
            stream.Write8(offset + 7, targetX);
            stream.Write8(offset + 8, tragetY);
            stream.Write8(offset + 9, endIcon);
        }

        public void WriteCheck(ByteStream stream, int index)
        {
            int offset = TweakData.ChozoHintChecksOffset + 0x2 * index;
            stream.Write8(offset, type);
            stream.Write8(offset + 1, equipEvent);
            stream.Write8(TweakData.ChozoHintTriggerEventsOffset + index, triggerEvent);
        }

        public string Area
        {
            get => Version.AreaNames[area];
            set => area = (byte)Version.AreaNames.ToList().IndexOf(value);
        }

        public string StartX
        {
            get => Hex.ToString(startX);
            set => startX = Hex.ToByte(value);
        }
        public string StartY
        {
            get => Hex.ToString(startY);
            set => startY = Hex.ToByte(value);
        }
        public string EndX
        {
            get => Hex.ToString(endX);
            set => endX = Hex.ToByte(value);
        }
        public string EndY
        {
            get => Hex.ToString(endY);
            set => endY = Hex.ToByte(value);
        }

        public string StartIcon
        {
            get => TweakData.StatueIcon[startIcon];
            set => startIcon = TweakData.StatueIcon.FirstOrDefault(pair => pair.Value == value).Key;
        }

        public string EndIcon
        {
            get => TweakData.StatueIcon[endIcon];
            set => endIcon = TweakData.StatueIcon.FirstOrDefault(pair => pair.Value == value).Key;
        }

        public string TargetArea
        {
            get => Version.AreaNames[tragetArea];
            set => tragetArea = (byte)Version.AreaNames.ToList().IndexOf(value);
        }
        public string TargetX
        {
            get => Hex.ToString(targetX);
            set => targetX = Hex.ToByte(value);
        }
        public string TargetY
        {
            get => Hex.ToString(tragetY);
            set => tragetY = Hex.ToByte(value);
        }

        public string Type
        {
            get => TweakData.CheckType[type];
            set => type = (byte)TweakData.CheckType.IndexOf(value);
        }

        public string EquipEvent
        {
            get => type switch
            {
                0 => TweakData.BeamBomb[(byte)Math.Log(equipEvent, 2)],
                1 => TweakData.SuitMisc[(byte)Math.Log(equipEvent, 2)],
                2 => TweakData.Events[equipEvent],
                _ => ""
            };
            set => equipEvent = type switch
            {
                0 => (byte)Math.Pow(2, TweakData.BeamBomb.IndexOf(value)),
                1 => (byte)Math.Pow(2, TweakData.SuitMisc.IndexOf(value)),
                2 => (byte)TweakData.Events.IndexOf(value),
                _ => 0
            };
        }
        public string TriggerEvent
        {
            get => TweakData.Events[triggerEvent];
            set => triggerEvent = (byte)TweakData.Events.IndexOf(value);
        }

        public string StartCoordinate
        {
            get => StartX + ", "  + StartY;
            set
            {
                value = value.Replace('，', ',');
                string[] xy = Regex.Replace(value, "\\s", "").Split(',');
                StartX = xy[0];
                StartY = xy[1];
            }
        }
        public string EndCoordinate
        {
            get => EndX + ", " + EndY;
            set
            {
                value = value.Replace('，', ',');
                string[] xy = Regex.Replace(value, "\\s", "").Split(',');
                EndX = xy[0];
                EndY = xy[1];
            }
        }
        public string TargetCoordinate
        {
            get => TargetX + ", " + TargetY;
            set
            {
                value = value.Replace('，', ',');
                string[] xy = Regex.Replace(value, "\\s", "").Split(',');
                TargetX = xy[0];
                TargetY = xy[1];
            }
        }

    }

    public struct DimLight
    {
        private byte dimEvent;
        public bool isDim;

        public readonly int offset;

        public DimLight(ByteStream stream, int index)
        {
            offset = TweakData.DimLightingEventsOffset + 2 * index;
            dimEvent = stream.Read8(offset);
            isDim = stream.Read8(offset + 1) != 0;
        }

        public void Write(ByteStream stream)
        {
            stream.Write8(offset, dimEvent);
            stream.Write8(offset + 1, (byte)(isDim?1:0));
        }

        public string DimEvent
        {
            get => TweakData.Events[dimEvent];
            set => dimEvent = (byte)TweakData.Events.IndexOf(value);
        }
    }

    public struct NavRoom
    {
        private byte area;
        private byte room;   //is mage room's id + 1

        public readonly int offset;

        public NavRoom(ByteStream stream, int index)
        {
            offset = TweakData.NavRoomLocationsOffset + 2 * index;
            area = stream.Read8(offset);
            room = stream.Read8(offset + 1);
        }

        public void Write(ByteStream stream)
        {
            stream.Write8(offset, area);
            stream.Write8(offset + 1, room);
        }

        public string Room
        {//auto -1,+1 for display 
            get => Hex.ToString(room - 1);
            set => room = (byte)(Hex.ToByte(value) + 1);
        }
        public string DimEvent
        {
            get => Version.AreaNames[area];
            set => area = (byte)Version.AreaNames.ToList().IndexOf(value);
        }
    }

    public class Monologue
    {
        private byte eventM;
        private byte elevator;
        private byte elevatorRoom;
        private byte cutscene;
        private ushort subEventStart;
        private ushort subEventEnd;

        private readonly int offset;

        public Monologue(ByteStream stream, int index)
        {
            offset = TweakData.MonologueEventsOffset + 8 * index;
            eventM = stream.Read8(offset);
            elevator = stream.Read8(offset + 1);
            elevatorRoom = stream.Read8(offset + 2);
            cutscene = stream.Read8(offset + 3);
            subEventStart = stream.Read16(offset + 4);
            subEventEnd = stream.Read16(offset + 6);
        }

        public void Write(ByteStream stream)
        {
            stream.Write8(offset, eventM);
            stream.Write8(offset + 1, elevator);
            stream.Write8(offset + 2, elevatorRoom);
            stream.Write8(offset + 3, cutscene);
            stream.Write16(offset + 4, subEventStart);
            stream.Write16(offset + 6, subEventEnd);
        }

        public string Event
        {
            get => TweakData.Events[eventM];
            set => eventM = (byte)TweakData.Events.IndexOf(value);
        }
        public string Elevator
        {
            get => Hex.ToString(elevator);
            set => elevator = Hex.ToByte(value);
        }
        public string ElevatorRoom
        {
            get => Hex.ToString(elevatorRoom);
            set => elevatorRoom = Hex.ToByte(value);
        }
        public string Cutscene
        {
            get => Hex.ToString(cutscene);
            set => cutscene = Hex.ToByte(value);
        }
        public string SubEventStart
        {
            get => TweakData.SubEvent[subEventStart];
            set => subEventStart = (byte)TweakData.SubEvent.IndexOf(value);
        }
        public string SubEventEnd
        {
            get => TweakData.SubEvent[subEventEnd];
            set => subEventEnd = (byte)TweakData.SubEvent.IndexOf(value);
        }
    }

    public class Security
    {
        private byte level;
        private byte area;
        private byte eventPre;
        private byte eventNew;
        private ushort subEvent;

        private readonly int offset;

        public Security(ByteStream stream, int index)
        {
            offset = TweakData.SecurityUnlockEventsOffset + 8 * index;
            level = stream.Read8(offset);
            area = stream.Read8(offset + 1);
            eventPre = stream.Read8(offset + 2);
            eventNew = stream.Read8(offset + 3);
            subEvent = stream.Read16(offset + 4);
        }

        public void Write(ByteStream stream)
        {
            stream.Write8(offset, level);
            stream.Write8(offset + 1, area);
            stream.Write8(offset + 2, eventPre);
            stream.Write8(offset + 3, eventNew);
            stream.Write16(offset + 4, subEvent);
        }

        public string Level
        {
            get => Hex.ToString(level);
            set { if (Hex.ToByte(value) > 4) throw new OverflowException(); else level = Hex.ToByte(value); } 
        }
        public string Area
        {
            get => Version.AreaNames[area];
            set => area = (byte)Version.AreaNames.ToList().IndexOf(value);
        }
        public string EventPre
        {
            get => TweakData.Events[eventPre];
            set => eventPre = (byte) TweakData.Events.IndexOf(value);
        }
        public string EventNew
        {
            get => TweakData.Events[eventNew];
            set => eventNew = (byte)TweakData.Events.IndexOf(value);
        }
        public string SubEvent
        {
            get => TweakData.SubEvent[subEvent];
            set => subEvent = (ushort)TweakData.SubEvent.IndexOf(value);
        }
    }

    public class Target
    {
        private byte conversation;
        private byte area;
        private byte x;
        private byte y; //x y is mage map coordinate + 1
        private byte direction;

        private readonly int offset;

        public Target(ByteStream stream, int index)
        {
            offset = TweakData.NavigationTargetsOffset + 8 * index;
            conversation = stream.Read8(offset);
            area = stream.Read8(offset + 1);
            x = stream.Read8(offset + 2);
            y = stream.Read8(offset + 3);
            direction = stream.Read8(offset + 4);
        }

        public void Write(ByteStream stream)
        {
            stream.Write8(offset, conversation);
            stream.Write8(offset + 1, area);
            stream.Write8(offset + 2, x);
            stream.Write8(offset + 3, y);
            stream.Write8(offset + 4, direction);
        }

        public string Conversation
        {
            get => Hex.ToString(conversation);
            set => Conversation = value;
        }
        public string Area
        {
            get => TweakData.TargetArea[area];
            set => area = (byte)TweakData.TargetArea.IndexOf(value);
        }
        public string Direction
        {
            get => TweakData.TargetDirection[direction];
            set => direction = (byte)TweakData.TargetDirection.IndexOf(value);
        }
        public string X
        {// auto -1,+1
            get => Hex.ToString(x - 1);
            set => x = (byte)(Hex.ToByte(value) + 1);
        }
        public string Y
        {//auto -1,+1
            get => Hex.ToString(y - 1);
            set => y = (byte)(Hex.ToByte(value) + 1);
        }
        public string Coordinate
        {
            get => X + ", " + Y;
            set
            {
                value = value.Replace('，', ',');
                string[] xy = Regex.Replace(value,"\\s","").Split(',');
                X = xy[0];
                Y = xy[1];
            }
        }
    }
}
