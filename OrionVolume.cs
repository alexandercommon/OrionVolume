using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows.Forms;
namespace OrionVolume
{
    static class Proto
    {
        public const string Group = "239.192.5.8";
        public const int BeaconPort = 5008;
        public const int MaxAtt = 96;
        public const int MainId = 0;
        public const string Format = @"{""authorative"":true,""version"":5,""cyclic_reports"":{""0x73"":[[""current_preset"",""ubyte"",3],[""power_on"",""ubyte"",1],[""muted"",""ubyte"",1],[""usb_mode"",""ubyte"",2],[""device_updated"",""ubyte"",1],[""tb_present"",""ubyte"",1],[""locked"",""ubyte"",1],[""atomic"",""ubyte"",1],[""usb_present"",""ubyte"",1],[""adat1_present"",""ubyte"",1],[""adat2_present"",""ubyte"",1],[""madi_present"",""ubyte"",1],[""spdif_present"",""ubyte"",1],[""base_index"",""byte"",4],[""us_pull_mode"",""ubyte"",2],[""eu_pull_mode"",""ubyte"",2],[""sync_source"",""ubyte""],[""freq_left"",""ubyte"",2],[""freq_right"",""ubyte"",2],[""level"",""ubyte"",2],[""mute_left"",""ubyte"",1],[""mute_right"",""ubyte"",1],[""sync_freq_hi"",""ubyte""],[""sync_freq_mid"",""ubyte""],[""sync_freq_low"",""ubyte""],[""madi_in_smux"",""ubyte"",1],[""madi_out_smux"",""ubyte"",1],[""spdif_src"",""ubyte"",1],[""usb_avail_channels"",""ubyte"",1],[""_reserved_1"",""ubyte"",4],[""brightness"",""ubyte""],[""adat_avail_channels"",""ubyte""],[""madi_avail_channels"",""ubyte""],[""volume_main"",""ubyte"",7],[""mute_main"",""ubyte"",1],[""volume_line"",""ubyte"",7],[""mute_line"",""ubyte"",1],[""monitor_trim"",""ubyte""],[""trim_line"",""ubyte""],[""trim_adc"",""ubyte""],[""_unused"",""ubyte * 47""],[""_unused2"",""ubyte * 42""],[""pm_bank_src"",""ubyte * 4""],[""peaks_a"",""ubyte * 32""],[""peaks_b"",""ubyte * 32""],[""peaks_mixer"",""ubyte * 32""],[""_unused3"",""ubyte * 16""],[""peaks_reverb_in0"",""ubyte * 2""],[""peaks_reverb_out0"",""ubyte * 2""]],""0x83"":[[""afx_meters"",{""fields"":[[""data"",""ubyte * 304""]]}]]},""requests"":{""set_none"":{""header"":{""report_id"":""0x70"",""ext2"":0,""ext3"":0},""params"":{""payload_id"":0,""fields"":[]}},""set_config_feature"":{""header"":{""report_id"":""0x70"",""ext2"":0,""ext3"":0},""params"":{""payload_id"":1,""fields"":[[""feature"",""ubyte""],[""status"",""ubyte""]]}},""set_dev_features"":{""header"":{""report_id"":""0x70"",""ext2"":0,""ext3"":0},""params"":{""payload_id"":2,""fields"":[[""features_number"",""ubyte"",8,1],[""registered"",""ubyte"",1],[""reserved"",""ubyte"",7,0]]}},""set_power"":{""header"":{""report_id"":""0x70"",""ext2"":0,""ext3"":0},""params"":{""payload_id"":3,""fields"":[[""power"",""ubyte""]]}},""set_samp_rate"":{""header"":{""report_id"":""0x70"",""ext2"":0,""ext3"":0},""params"":{""payload_id"":4,""fields"":[[""srate_idx"",""ubyte""]]}},""set_sync_source"":{""header"":{""report_id"":""0x70"",""ext2"":0,""ext3"":0},""params"":{""payload_id"":5,""fields"":[[""src_index"",""ubyte""]]}},""set_volume"":{""header"":{""report_id"":""0x70"",""ext2"":0,""ext3"":0},""params"":{""payload_id"":6,""fields"":[[""id"",""ubyte""],[""volume"",""ubyte""]]}},""set_mute"":{""header"":{""report_id"":""0x70"",""ext2"":0,""ext3"":0},""params"":{""payload_id"":7,""fields"":[[""id"",""ubyte""],[""mute"",""ubyte""]]}},""preset_save"":{""header"":{""report_id"":""0x70"",""ext2"":0,""ext3"":0},""params"":{""payload_id"":8,""fields"":[[""preset_idx"",""ubyte""]]}},""preset_recall"":{""header"":{""report_id"":""0x70"",""ext2"":0,""ext3"":0},""params"":{""payload_id"":9,""fields"":[[""preset_idx"",""ubyte""]]}},""set_sine_gen"":{""header"":{""report_id"":""0x70"",""ext2"":0,""ext3"":0},""params"":{""payload_id"":10,""fields"":[[""freq_left"",""ubyte"",2],[""freq_righ"",""ubyte"",2],[""level"",""ubyte"",2],[""mute_left"",""ubyte"",1],[""mute_right"",""ubyte"",1]]}},""set_brightness"":{""header"":{""report_id"":""0x70"",""ext2"":0,""ext3"":0},""params"":{""payload_id"":11,""fields"":[[""brightness"",""ubyte""]]}},""set_trim_config"":{""header"":{""report_id"":""0x70"",""ext2"":0,""ext3"":0},""params"":{""payload_id"":12,""fields"":[[""trim_id"",""ubyte""],[""control"",""ubyte""],[""level"",{""elem_type"":""uint8 * 2"",""count"":32}]]},""auto_send_notification"":true},""set_spdif_src"":{""header"":{""report_id"":""0x70"",""ext2"":0,""ext3"":0},""params"":{""payload_id"":13,""fields"":[[""spdif_src"",""ubyte""]]}},""set_smux_mode"":{""header"":{""report_id"":""0x70"",""ext2"":0,""ext3"":0},""params"":{""payload_id"":14,""fields"":[[""id"",""ubyte""],[""mode"",""ubyte""]]}},""set_usb_channels"":{""header"":{""report_id"":""0x70"",""ext2"":0,""ext3"":0},""params"":{""payload_id"":15,""fields"":[[""channels"",""ubyte""]]}},""set_peak_source"":{""header"":{""report_id"":""0x70"",""ext2"":0,""ext3"":0},""params"":{""payload_id"":16,""fields"":[[""bank_id"",""ubyte""],[""peak_src"",""ubyte""]]},""auto_send_notification"":true},""set_mixer_cfg"":{""header"":{""report_id"":""0x70"",""ext2"":0,""ext3"":0},""params"":{""payload_id"":17,""fields"":[[""mixer_id"",""ubyte""],[""channel"",""ubyte""],[""level"",""ubyte""],[""pan"",""ubyte"",6],[""mute"",""ubyte"",1],[""solo"",""ubyte"",1],[""send"",""ubyte""]]},""auto_send_notification"":true},""set_routing"":{""header"":{""report_id"":""0x70"",""ext2"":0,""ext3"":0},""params"":{""payload_id"":18,""fields"":[[""bank_idx"",""ubyte""],[""bank_configs"",{""elem_type"":""byte * 2"",""count"":32}]]},""auto_send_notification"":true},""set_stereo_link"":{""header"":{""report_id"":""0x70"",""ext2"":0,""ext3"":0},""params"":{""payload_id"":19,""fields"":[[""periph_id"",""ubyte""],[""channel_id"",""ubyte""],[""linked"",""ubyte""]]},""auto_send_notification"":true},""set_afx_order"":{""header"":{""report_id"":""0x70"",""ext2"":0,""ext3"":0},""params"":{""payload_id"":21,""fields"":[[""ch_id"",""ubyte""],[""slots"",{""elem_type"":{""fields"":[[""type"",""ubyte""],[""inst"",""ubyte""]]},""count"":8}]]},""auto_send_notification"":true},""set_afx_bypass"":{""header"":{""report_id"":""0x70"",""ext2"":0,""ext3"":0},""params"":{""payload_id"":22,""fields"":[[""periph_id"",""ubyte""],[""periph_type"",""ubyte""],[""enabled"",""ubyte""]]},""auto_send_notification"":true},""set_predefined_preset"":{""header"":{""report_id"":""0x70"",""ext2"":0,""ext3"":0},""params"":{""payload_id"":23,""fields"":[[""effect_type"",""ubyte""],[""inst_id"",""ubyte""],[""preset_num"",""ubyte""]]},""auto_send_notification"":true},""set_reverb_config"":{""header"":{""report_id"":""0x70"",""ext2"":0,""ext3"":0},""params"":{""payload_id"":24,""fields"":[[""mixer_id"",""ubyte""],[""room_size"",""ubyte""],[""color"",""ubyte""],[""predelay"",""ubyte""],[""density"",""ubyte"",8,100],[""early_ref_gain"",""ubyte""],[""late_ref_delay"",""ubyte""],[""richness"",""ubyte""],[""reverb_time"",""ubyte""],[""reverb_level"",""ubyte""],[""on"",""ubyte""]]},""auto_send_notification"":true},""set_panning_law"":{""header"":{""report_id"":""0x70"",""ext2"":0,""ext3"":0},""params"":{""payload_id"":25,""fields"":[[""panning"",""ubyte""]]}},""set_tb_latency"":{""header"":{""report_id"":""0xE0"",""ext2"":0,""ext3"":0},""params"":{""fields"":[[""mode"",""int32""],[""buffer_adjust_in"",""int32"",32,0],[""buffer_adjust_out"",""int32"",32,0],[""latency_adjust_in"",""int32"",32,0],[""latency_adjust_out"",""int32"",32,0]]}},""set_daw_mode"":{""header"":{""report_id"":""0x70"",""ext2"":0,""ext3"":0},""params"":{""payload_id"":27,""fields"":[[""enabled"",""int32""],[""afx_num_channels"",""int32""]]}},""get_routing"":{""header"":{""report_id"":""0x74"",""ext2"":3,""ext3"":0},""returns"":{""fields"":[[""bank_idx"",""uint8""],[""bank_configs"",{""fields"":[[""in_periph_id"",""uint8""],[""in_chann"",""uint8""]],""count"":64}]]}},""get_mixer"":{""header"":{""report_id"":""0x74"",""ext2"":4,""ext3"":0},""returns"":{""fields"":[[""level"",""uint8""],[""pan"",""uint8"",6],[""mute"",""uint8"",1],[""solo"",""uint8"",1],[""send"",""uint8""]],""count"":33}},""get_reverb_config"":{""header"":{""report_id"":""0x74"",""ext2"":10,""ext3"":0},""returns"":{""fields"":[[""mixer_id"",""ubyte""],[""room_size"",""ubyte""],[""color"",""ubyte""],[""predelay"",""ubyte""],[""density"",""ubyte""],[""early_ref_gain"",""ubyte""],[""late_ref_delay"",""ubyte""],[""richness"",""ubyte""],[""reverb_time"",""ubyte""],[""reverb_level"",""ubyte""],[""on"",""ubyte""]]}},""get_mixer_links"":{""header"":{""report_id"":""0x74"",""ext2"":11,""ext3"":3},""returns"":{""fields"":[[""linked"",""ubyte""]],""count"":64}},""get_afx_links"":{""header"":{""report_id"":""0x74"",""ext2"":11,""ext3"":4},""returns"":{""fields"":[[""linked"",""ubyte""]],""count"":20}},""get_afx_available_instances"":{""header"":{""report_id"":""0x74"",""ext2"":12,""ext3"":0},""returns"":{""fields"":[[""type_id"",""ubyte""],[""inst_count"",""ubyte""]],""count"":-1}},""get_trim_configs"":{""header"":{""report_id"":""0x74"",""ext2"":13,""ext3"":0},""returns"":{""fields"":[[""trim_id"",""ubyte""],[""control"",""ubyte""],[""levels"",{""fields"":[[""whole"",""uint8""],[""fract"",""uint8""]],""count"":32}]],""count"":3}},""get_assignment_status"":{""header"":{""report_id"":""0x74"",""ext2"":17,""ext3"":0},""returns"":{""fields"":[[""status"",""uint8""]]}},""get_feature_mask"":{""header"":{""report_id"":""0x74"",""ext2"":17,""ext3"":1},""returns"":{""fields"":[[""payload"",""uint8 * 200""]]}},""get_assignment_request"":{""header"":{""report_id"":""0x74"",""ext2"":17,""ext3"":2},""returns"":{""fields"":[[""length"",""uint16""],[""request"",""uint8 * 301""]]}},""get_cmd_set_assignment"":{""header"":{""report_id"":""0x74"",""ext2"":17,""ext3"":3},""params"":{""fields"":[[""length"",""uint16""],[""message"",""uint8 * 301""]]},""returns"":{""fields"":[[""status"",""uint8""],[""length"",""uint16""],[""message"",""uint8 * 301""]]}},""get_afx_remaining_featured_instances"":{""header"":{""report_id"":""0x74"",""ext2"":21,""ext3"":0},""returns"":{""fields"":[[""type_id"",""ubyte""],[""inst_count"",""byte""]],""count"":91}},""get_afx_strip_order"":{""header"":{""report_id"":""0x74"",""ext2"":25,""ext3"":0},""returns"":{""fields"":[[""slots"",{""fields"":[[""type"",""ubyte""],[""inst"",""ubyte""]],""count"":8}]],""count"":1}},""get_tb_latency"":{""header"":{""report_id"":""0xE2"",""ext2"":0,""ext3"":0},""returns"":{""fields"":[[""mode"",""int32""],[""buffer_adjust_in"",""int32""],[""buffer_adjust_out"",""int32""],[""latency_adjust_in"",""int32""],[""latency_adjust_out"",""int32""]]}},""get_daw_mode"":{""header"":{""report_id"":""0x74"",""ext2"":19,""ext3"":0},""returns"":{""fields"":[[""enabled"",""int32""],[""afx_num_channels"",""int32""]]}}}}";
        public static JavaScriptSerializer NewJson()
        {
            var j = new JavaScriptSerializer();
            j.MaxJsonLength = int.MaxValue;
            return j;
        }
        public static object FindKey(object o, string key)
        {
            var d = o as IDictionary;
            if (d != null)
            {
                if (d.Contains(key)) return d[key];
                foreach (var v in d.Values)
                {
                    var r = FindKey(v, key);
                    if (r != null) return r;
                }
                return null;
            }
            var l = o as IList;
            if (l != null)
                foreach (var v in l)
                {
                    var r = FindKey(v, key);
                    if (r != null) return r;
                }
            return null;
        }
        public static int ToInt(object v)
        {
            if (v == null) return 0;
            if (v is bool) return (bool)v ? 1 : 0;
            return Convert.ToInt32(v, CultureInfo.InvariantCulture);
        }
        public static string Str(IDictionary<string, object> d, string key)
        {
            object v;
            if (d == null || !d.TryGetValue(key, out v) || v == null) return "";
            return Convert.ToString(v, CultureInfo.InvariantCulture);
        }
        public static bool IsTimeout(Exception e)
        {
            var s = e as SocketException ?? e.InnerException as SocketException;
            return s != null && (s.SocketErrorCode == SocketError.TimedOut || s.SocketErrorCode == SocketError.WouldBlock);
        }
    }
    sealed class Link : IDisposable
    {
        readonly TcpClient tcp;
        readonly NetworkStream ns;
        readonly object wlock = new object();
        readonly JavaScriptSerializer json = Proto.NewJson();
        public Link(string host, int port)
        {
            tcp = new TcpClient();
            try
            {
                var ar = tcp.BeginConnect(host, port, null, null);
                if (!ar.AsyncWaitHandle.WaitOne(3000)) throw new TimeoutException("timed out");
                tcp.EndConnect(ar);
                tcp.NoDelay = true;
                ns = tcp.GetStream();
                ns.WriteTimeout = 3000;
                Send("[\"initialize_format\",[" + Proto.Format + "],{}]");
            }
            catch
            {
                tcp.Close();
                throw;
            }
        }
        public void Send(string text)
        {
            var data = Encoding.UTF8.GetBytes(text);
            int n = data.Length + 4;
            var buf = new byte[n];
            buf[0] = (byte)(n >> 24);
            buf[1] = (byte)(n >> 16);
            buf[2] = (byte)(n >> 8);
            buf[3] = (byte)n;
            Buffer.BlockCopy(data, 0, buf, 4, data.Length);
            lock (wlock) ns.Write(buf, 0, n);
        }
        public void Request(string name, params int[] args)
        {
            Send("[\"" + name + "\",[" + string.Join(",", Array.ConvertAll(args, a => a.ToString(CultureInfo.InvariantCulture))) + "],{}]");
        }
        byte[] ReadExact(int n)
        {
            var buf = new byte[n];
            int got = 0;
            while (got < n)
            {
                int r = ns.Read(buf, got, n - got);
                if (r <= 0) throw new IOException("the Antelope server closed the connection");
                got += r;
            }
            return buf;
        }
        public object Read()
        {
            var h = ReadExact(4);
            int size = (h[0] << 24) | (h[1] << 16) | (h[2] << 8) | h[3];
            if (size < 4 || size > 64 << 20) throw new IOException("the server sent a malformed message");
            return json.DeserializeObject(Encoding.UTF8.GetString(ReadExact(size - 4)));
        }
        public bool ReadState(int waitMs, out int volume, out bool mute, out bool serverNote)
        {
            volume = 0;
            mute = false;
            serverNote = false;
            var end = DateTime.UtcNow.AddMilliseconds(waitMs);
            while (DateTime.UtcNow < end)
            {
                tcp.ReceiveTimeout = Math.Max(100, (int)(end - DateTime.UtcNow).TotalMilliseconds);
                object msg;
                try
                {
                    msg = Read();
                }
                catch (IOException e)
                {
                    if (Proto.IsTimeout(e)) break;
                    throw;
                }
                var d = msg as IDictionary<string, object>;
                if (d != null)
                {
                    if (Proto.Str(d, "type") == "rejection") throw new IOException("the Antelope server rejected the connection");
                    object c;
                    if (d.TryGetValue("contents", out c) && c != null && (c as string ?? json.Serialize(c)).Contains("Server ver.")) serverNote = true;
                }
                var v = Proto.FindKey(msg, "volume_main");
                if (v != null)
                {
                    volume = Proto.ToInt(v);
                    mute = Proto.ToInt(Proto.FindKey(msg, "mute_main")) != 0;
                    tcp.ReceiveTimeout = 0;
                    return true;
                }
            }
            return false;
        }
        public void Dispose()
        {
            try { tcp.Close(); } catch { }
        }
    }
    static class Finder
    {
        static List<IPAddress> LocalIPv4s()
        {
            var ips = new List<IPAddress> { IPAddress.Loopback };
            try
            {
                foreach (var a in Dns.GetHostAddresses(Dns.GetHostName()))
                    if (a.AddressFamily == AddressFamily.InterNetwork && !ips.Contains(a)) ips.Add(a);
            }
            catch (SocketException) { }
            return ips;
        }
        public static List<Dictionary<string, object>> Discover(int waitMs)
        {
            var found = new Dictionary<string, Dictionary<string, object>>();
            var order = new List<string>();
            var json = Proto.NewJson();
            var group = IPAddress.Parse(Proto.Group);
            using (var udp = new UdpClient())
            {
                try { udp.ExclusiveAddressUse = false; } catch (SocketException) { }
                udp.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                udp.Client.Bind(new IPEndPoint(IPAddress.Any, Proto.BeaconPort));
                foreach (var ip in LocalIPv4s())
                    try { udp.JoinMulticastGroup(group, ip); } catch (SocketException) { }
                try { udp.JoinMulticastGroup(group); } catch (SocketException) { }
                var end = DateTime.UtcNow.AddMilliseconds(waitMs);
                while (true)
                {
                    int left = (int)(end - DateTime.UtcNow).TotalMilliseconds;
                    if (left <= 0) break;
                    udp.Client.ReceiveTimeout = Math.Max(50, left);
                    var ep = new IPEndPoint(IPAddress.Any, 0);
                    byte[] data;
                    try
                    {
                        data = udp.Receive(ref ep);
                    }
                    catch (SocketException e)
                    {
                        if (Proto.IsTimeout(e)) break;
                        throw;
                    }
                    Dictionary<string, object> msg;
                    try
                    {
                        msg = json.DeserializeObject(Encoding.UTF8.GetString(data)) as Dictionary<string, object>;
                    }
                    catch (ArgumentException)
                    {
                        continue;
                    }
                    if (msg == null || !msg.ContainsKey("port")) continue;
                    var k = Proto.Str(msg, "uuid") + "|" + Proto.Str(msg, "ip") + "|" + Proto.Str(msg, "port");
                    if (!found.ContainsKey(k)) order.Add(k);
                    found[k] = msg;
                }
            }
            return order.ConvertAll(k => found[k]);
        }
        public static Dictionary<string, object> Pick(List<Dictionary<string, object>> services)
        {
            var json = Proto.NewJson();
            var control = services.FindAll(s => Proto.Str(s, "type").ToLowerInvariant().Contains("control"));
            if (control.Count == 0) control = services;
            foreach (var key in new[] { "oriontb_iii", "oriontbiii", "orion32+ gen 3", "oriontb", "orion" })
                foreach (var s in control)
                    if (json.Serialize(s).ToLowerInvariant().Contains(key)) return s;
            return control.Count > 0 ? control[0] : null;
        }
    }
    static class Store
    {
        static string FilePath()
        {
            var dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (string.IsNullOrEmpty(dir)) dir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            return Path.Combine(dir, "orion_volume.json");
        }
        public static Dictionary<string, object> Load()
        {
            try
            {
                var d = Proto.NewJson().DeserializeObject(File.ReadAllText(FilePath(), Encoding.UTF8)) as Dictionary<string, object>;
                if (d != null) return d;
            }
            catch { }
            return new Dictionary<string, object>();
        }
        public static void Save(Dictionary<string, object> d)
        {
            try { File.WriteAllText(FilePath(), Proto.NewJson().Serialize(d), new UTF8Encoding(false)); } catch { }
        }
    }
    sealed class MainForm : Form
    {
        static Color C(int rgb) { return Color.FromArgb(255, (rgb >> 16) & 255, (rgb >> 8) & 255, rgb & 255); }
        static readonly Color Bg = C(0x16171a), SheetBg = C(0x1f2125), FieldBg = C(0x0f1012), Edge = C(0x34373e), Hair = C(0x26282d), Ink = C(0xe9eaed), Dim = C(0x8a8e97), Faint = C(0x5a5e67), Accent = C(0xf2a33a), AccentHot = C(0xf7b85f), Good = C(0x3dd68c), Bad = C(0xef5a5f), Groove = C(0x0b0c0e);
        static readonly int[] Majors = { 0, -5, -10, -15, -20, -30, -40, -50, -60, -75, -96 };
        static readonly Bitmap MeasureBmp = new Bitmap(1, 1);
        enum Tone { Idle, Busy, Ok, Error }
        enum Hit { None, Gear, Find, Connect, Mute, Fader, Sheet }
        [DllImport("user32.dll")] static extern int GetDpiForWindow(IntPtr hwnd);
        [DllImport("dwmapi.dll")] static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int value, int size);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)] static extern IntPtr SendMessage(IntPtr hwnd, int msg, IntPtr w, string l);
        [StructLayout(LayoutKind.Sequential)] struct RECT { public int L, T, R, B; }
        readonly TextBox tbHost, tbPort;
        readonly System.Windows.Forms.Timer sendTimer, startTimer;
        readonly ToolTip tip = new ToolTip();
        readonly Dictionary<string, object> settings;
        readonly bool ready;
        Link link;
        int linkId, lastSent = int.MinValue, lastUserTick, level = -Proto.MaxAtt, dpi = 96, wheelAcc;
        bool muted, sheetOpen, finding, connecting;
        string deviceName = "Orion", stateText = "Not connected", message = "", tipText, connectedTo = "";
        Tone tone = Tone.Idle;
        float s = 1f, cx, trackTop, trackBot, capW, capH;
        RectangleF rTitle, rGear, rSheet, rHost, rPort, rFind, rConnect, rMsg, rFader, rReadout, rMute;
        Font fTitle, fSmall, fTick, fBig, fUnit, fButton, fField;
        Hit hover = Hit.None, pressed = Hit.None;
        float? grab;
        static bool IsWindows { get { return Environment.OSVersion.Platform == PlatformID.Win32NT; } }
        public MainForm()
        {
            Text = "Orion Volume";
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Bg;
            ForeColor = Ink;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            try { Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath); } catch { }
            tbHost = MakeBox();
            tbPort = MakeBox();
            tbPort.MaxLength = 5;
            Controls.Add(tbHost);
            Controls.Add(tbPort);
            sendTimer = new System.Windows.Forms.Timer { Interval = 40 };
            sendTimer.Tick += (o, e) => { sendTimer.Stop(); SendNow(); };
            startTimer = new System.Windows.Forms.Timer { Interval = 200 };
            startTimer.Tick += (o, e) => { startTimer.Stop(); Start(); };
            settings = Store.Load();
            using (var g = Graphics.FromHwnd(IntPtr.Zero)) dpi = Math.Max(96, (int)Math.Round(g.DpiX));
            ClientSize = new Size(Px(164), Px(392));
            UpdateMinimum();
            int x, y, w, h;
            if (TryInt("x", out x) && TryInt("y", out y) && TryInt("w", out w) && TryInt("h", out h))
            {
                var r = new Rectangle(x, y, w, h);
                foreach (var sc in Screen.AllScreens)
                    if (sc.WorkingArea.IntersectsWith(r))
                    {
                        StartPosition = FormStartPosition.Manual;
                        Bounds = r;
                        break;
                    }
            }
            tbHost.Text = Proto.Str(settings, "host");
            tbPort.Text = Proto.Str(settings, "port");
            var name = Proto.Str(settings, "name");
            if (name != "") deviceName = name;
            ready = true;
            Relayout();
        }
        bool TryInt(string key, out int v)
        {
            v = 0;
            object o;
            if (!settings.TryGetValue(key, out o) || o == null) return false;
            try { v = Proto.ToInt(o); return true; } catch { return false; }
        }
        TextBox MakeBox()
        {
            var t = new TextBox { BorderStyle = BorderStyle.None, BackColor = FieldBg, ForeColor = Ink, Visible = false };
            t.KeyDown += (o, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; Connect(); } };
            t.GotFocus += (o, e) => Invalidate();
            t.LostFocus += (o, e) => Invalidate();
            return t;
        }
        int Px(float logical) { return (int)Math.Round(logical * dpi / 96f); }
        void UpdateMinimum()
        {
            MinimumSize = SizeFromClientSize(new Size(Px(136), Px(256)));
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (!IsWindows) return;
            try
            {
                int d = GetDpiForWindow(Handle);
                if (d > 0 && d != dpi)
                {
                    var cs = ClientSize;
                    float k = d / (float)dpi;
                    dpi = d;
                    UpdateMinimum();
                    if (StartPosition != FormStartPosition.Manual) ClientSize = new Size((int)(cs.Width * k), (int)(cs.Height * k));
                }
            }
            catch { }
            try
            {
                int on = 1;
                if (DwmSetWindowAttribute(Handle, 20, ref on, 4) != 0) DwmSetWindowAttribute(Handle, 19, ref on, 4);
            }
            catch { }
            try
            {
                SendMessage(tbHost.Handle, 0x1501, (IntPtr)1, "Server address");
                SendMessage(tbPort.Handle, 0x1501, (IntPtr)1, "Port");
            }
            catch { }
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0xA3 && m.WParam == (IntPtr)2) return;
            if (m.Msg == 0x02E0)
            {
                dpi = m.WParam.ToInt32() & 0xFFFF;
                var r = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));
                MinimumSize = Size.Empty;
                Bounds = new Rectangle(r.L, r.T, r.R - r.L, r.B - r.T);
                UpdateMinimum();
                Relayout();
                m.Result = IntPtr.Zero;
                return;
            }
            base.WndProc(ref m);
            if (m.Msg == 0x84 && m.Result == (IntPtr)1)
            {
                long lp = m.LParam.ToInt64();
                var p = PointToClient(new Point((short)(lp & 0xFFFF), (short)((lp >> 16) & 0xFFFF)));
                if (Draggable(p)) m.Result = (IntPtr)2;
            }
        }
        bool Draggable(Point p)
        {
            if (rGear.Contains(p)) return false;
            if (p.Y < 36 * s) return true;
            if (sheetOpen) return false;
            var h = HitTest(p);
            return h == Hit.None || (h == Hit.Fader && link == null);
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            startTimer.Start();
        }
        void Start()
        {
            if (Proto.Str(settings, "host") != "" && Proto.Str(settings, "port") != "") Connect();
            else Find();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Relayout();
        }
        void Relayout()
        {
            if (!ready) return;
            var cs = ClientSize;
            if (cs.Width < 2 || cs.Height < 2) return;
            float u = dpi / 96f;
            float f = Math.Max(0.85f, Math.Min(2.4f, Math.Min(cs.Width / (164f * u), cs.Height / (392f * u))));
            float ns = u * f;
            if (fTitle == null || Math.Abs(ns - s) > 0.01f)
            {
                s = ns;
                MakeFonts();
            }
            DoLayout();
            Invalidate();
        }
        void MakeFonts()
        {
            var olds = new[] { fTitle, fSmall, fTick, fBig, fUnit, fButton, fField };
            fTitle = new Font("Segoe UI Semibold", 12.5f * s, FontStyle.Regular, GraphicsUnit.Pixel);
            fSmall = new Font("Segoe UI", 11.5f * s, FontStyle.Regular, GraphicsUnit.Pixel);
            fTick = new Font("Segoe UI", 10.5f * s, FontStyle.Regular, GraphicsUnit.Pixel);
            fBig = new Font("Segoe UI Light", 34f * s, FontStyle.Regular, GraphicsUnit.Pixel);
            fUnit = new Font("Segoe UI", 14f * s, FontStyle.Regular, GraphicsUnit.Pixel);
            fButton = new Font("Segoe UI Semibold", 11.5f * s, FontStyle.Regular, GraphicsUnit.Pixel);
            fField = new Font("Segoe UI", 12.5f * s, FontStyle.Regular, GraphicsUnit.Pixel);
            tbHost.Font = fField;
            tbPort.Font = fField;
            foreach (var old in olds)
                if (old != null) old.Dispose();
        }
        void DoLayout()
        {
            float cw = ClientSize.Width, ch = ClientSize.Height, pad = 10 * s, hh = 36 * s;
            rTitle = new RectangleF(pad + 14 * s, 0, cw - 2 * pad - 14 * s - 30 * s, hh);
            rGear = new RectangleF(cw - pad - 26 * s, (hh - 26 * s) / 2, 26 * s, 26 * s);
            float y = hh + 4 * s, fh = 28 * s, gap = 6 * s, portW = 54 * s;
            rHost = new RectangleF(pad, y, cw - 2 * pad - portW - gap, fh);
            rPort = new RectangleF(cw - pad - portW, y, portW, fh);
            y += fh + gap;
            float bw = (float)Math.Floor((cw - 2 * pad - gap) / 2);
            rFind = new RectangleF(pad, y, bw, fh);
            rConnect = new RectangleF(pad + bw + gap, y, cw - 2 * pad - bw - gap, fh);
            y += fh + gap;
            float mh = 0;
            if (message != "")
            {
                using (var g = Graphics.FromImage(MeasureBmp))
                    mh = Math.Min(g.MeasureString(message, fSmall, (int)(cw - 2 * pad)).Height, fSmall.GetHeight() * 5);
                rMsg = new RectangleF(pad, y - 1 * s, cw - 2 * pad, mh + 2);
                y += mh + gap;
            }
            else rMsg = RectangleF.Empty;
            rSheet = new RectangleF(0, hh, cw, y + 4 * s - hh);
            float mH = 26 * s, mW = 84 * s;
            rMute = new RectangleF((float)Math.Round(cw / 2 - mW / 2), ch - pad - 2 * s - mH, mW, mH);
            rReadout = new RectangleF(0, rMute.Top - 4 * s - 44 * s, cw, 44 * s);
            rFader = new RectangleF(0, hh + 6 * s, cw, rReadout.Top - hh - 8 * s);
            capW = 42 * s;
            capH = 22 * s;
            trackTop = rFader.Top + capH / 2 + 2 * s;
            trackBot = rFader.Bottom - capH / 2;
            cx = (float)Math.Round(cw / 2 - 14 * s);
            tbHost.Visible = tbPort.Visible = sheetOpen;
            if (sheetOpen)
            {
                PlaceBox(tbHost, rHost);
                PlaceBox(tbPort, rPort);
            }
        }
        void PlaceBox(TextBox t, RectangleF r)
        {
            int inset = (int)Math.Round(8 * s);
            t.SetBounds((int)r.X + inset, (int)Math.Round(r.Y + (r.Height - t.Height) / 2), (int)r.Width - 2 * inset, t.Height);
        }
        float YOf(int v) { return trackTop + (-v) / (float)Proto.MaxAtt * (trackBot - trackTop); }
        int VOf(float y)
        {
            int v = -(int)Math.Round((y - trackTop) / (trackBot - trackTop) * Proto.MaxAtt);
            return Math.Max(-Proto.MaxAtt, Math.Min(0, v));
        }
        static GraphicsPath Round(RectangleF r, float rad)
        {
            var p = new GraphicsPath();
            float d = Math.Min(rad * 2, Math.Min(r.Width, r.Height));
            if (d <= 0.5f) { p.AddRectangle(r); return p; }
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }
        static void Fill(Graphics g, RectangleF r, float rad, Color c)
        {
            using (var p = Round(r, rad)) using (var b = new SolidBrush(c)) g.FillPath(b, p);
        }
        static void Stroke(Graphics g, RectangleF r, float rad, Color c, float w)
        {
            using (var p = Round(r, rad)) using (var pen = new Pen(c, w)) g.DrawPath(pen, p);
        }
        static void Write(Graphics g, string t, Font f, Color c, RectangleF r, StringAlignment h)
        {
            using (var sf = new StringFormat(StringFormatFlags.NoWrap) { Alignment = h, LineAlignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisCharacter })
            using (var b = new SolidBrush(c)) g.DrawString(t, f, b, r, sf);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (!ready || fTitle == null) return;
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            g.Clear(Bg);
            DrawFader(g);
            DrawReadout(g);
            DrawMute(g);
            if (sheetOpen) DrawSheet(g);
            DrawHeader(g);
        }
        void DrawHeader(Graphics g)
        {
            float pad = 10 * s, hh = 36 * s, dx = pad + 4 * s, dy = hh / 2;
            var dot = tone == Tone.Ok ? Good : tone == Tone.Busy ? Accent : tone == Tone.Error ? Bad : Faint;
            if (tone == Tone.Ok)
                using (var b = new SolidBrush(Color.FromArgb(50, dot))) g.FillEllipse(b, dx - 7 * s, dy - 7 * s, 14 * s, 14 * s);
            using (var b = new SolidBrush(dot)) g.FillEllipse(b, dx - 4 * s, dy - 4 * s, 8 * s, 8 * s);
            Write(g, link != null ? deviceName : stateText, fTitle, link != null ? Ink : Dim, rTitle, StringAlignment.Near);
            if (hover == Hit.Gear || sheetOpen) Fill(g, rGear, 6 * s, C(0x2a2c32));
            DrawGear(g, new PointF(rGear.X + rGear.Width / 2, rGear.Y + rGear.Height / 2), 7.5f * s, sheetOpen ? Accent : hover == Hit.Gear ? Ink : Dim, sheetOpen || hover == Hit.Gear ? C(0x2a2c32) : Bg);
            if (!sheetOpen)
                using (var p = new Pen(Hair, Math.Max(1, s))) g.DrawLine(p, 0, hh - 0.5f, ClientSize.Width, hh - 0.5f);
        }
        static void DrawGear(Graphics g, PointF c, float r, Color col, Color hole)
        {
            const int n = 8;
            var pts = new List<PointF>();
            float ri = r * 0.72f;
            for (int i = 0; i < n; i++)
            {
                double a = i * 2 * Math.PI / n;
                foreach (var t in new[] { -0.36, -0.17, 0.17, 0.36 })
                {
                    float rr = Math.Abs(t) > 0.3 ? ri : r;
                    pts.Add(new PointF(c.X + (float)(Math.Cos(a + t) * rr), c.Y + (float)(Math.Sin(a + t) * rr)));
                }
            }
            using (var b = new SolidBrush(col)) g.FillPolygon(b, pts.ToArray());
            using (var b = new SolidBrush(hole)) g.FillEllipse(b, c.X - r * 0.32f, c.Y - r * 0.32f, r * 0.64f, r * 0.64f);
        }
        void DrawFader(Graphics g)
        {
            bool on = link != null;
            float span = trackBot - trackTop;
            float xl = cx - capW / 2 - 5 * s, xr = cx + capW / 2 + 5 * s;
            float lh = fTick.Size * 1.3f;
            var keep = new List<int>();
            float last = float.NegativeInfinity;
            foreach (var v in Majors)
            {
                if (v == -Proto.MaxAtt) continue;
                float y = YOf(v);
                if (y - last >= lh) { keep.Add(v); last = y; }
            }
            float yb = YOf(-Proto.MaxAtt);
            while (keep.Count > 0 && yb - YOf(keep[keep.Count - 1]) < lh) keep.RemoveAt(keep.Count - 1);
            keep.Add(-Proto.MaxAtt);
            bool minor = span * 5 / Proto.MaxAtt >= 4 * s;
            using (var pMajor = new Pen(C(0x4a4e57), Math.Max(1, 1.2f * s)))
            using (var pMinor = new Pen(C(0x30333a), Math.Max(1, s)))
            {
                for (int v = 0; v >= -Proto.MaxAtt; v -= (v == -95 ? 1 : 5))
                {
                    bool big = keep.Contains(v);
                    if (!big && (!minor || v == -95)) continue;
                    float y = (float)Math.Round(YOf(v)) + 0.5f;
                    float len = (big ? 8 : 4) * s;
                    var p = big ? pMajor : pMinor;
                    g.DrawLine(p, xl - len, y, xl, y);
                    g.DrawLine(p, xr, y, xr + len, y);
                }
            }
            foreach (var v in keep)
            {
                var t = v == -Proto.MaxAtt ? "−∞" : v == 0 ? "0" : "−" + (-v);
                Write(g, t, fTick, v == 0 && on ? Ink : Dim, new RectangleF(xr + 12 * s, YOf(v) - lh, ClientSize.Width - xr - 12 * s, lh * 2), StringAlignment.Near);
            }
            var groove = new RectangleF(cx - 3 * s, trackTop - 3 * s, 6 * s, span + 6 * s);
            Fill(g, groove, 3 * s, Groove);
            float cy = YOf(level);
            var fillCol = !on ? C(0x3a3d44) : muted ? Bad : Accent;
            if (trackBot + 3 * s - cy > 1) Fill(g, new RectangleF(cx - 3 * s, cy, 6 * s, trackBot + 3 * s - cy), 3 * s, fillCol);
            Stroke(g, groove, 3 * s, C(0x24262b), 1);
            var cap = new RectangleF(cx - capW / 2, cy - capH / 2, capW, capH);
            var sh1 = cap; sh1.Offset(0, 3 * s); sh1.Inflate(2 * s, 1 * s);
            Fill(g, sh1, 6 * s, Color.FromArgb(60, 0, 0, 0));
            var sh2 = cap; sh2.Offset(0, 1.5f * s);
            Fill(g, sh2, 5 * s, Color.FromArgb(120, 0, 0, 0));
            using (var p = Round(cap, 4 * s))
            using (var b = new LinearGradientBrush(new PointF(0, cap.Top), new PointF(0, cap.Bottom + 1), on ? C(0xf5f5f6) : C(0x6f727a), on ? C(0xb4b6bb) : C(0x55585f)))
            {
                g.FillPath(b, p);
                using (var pen = new Pen(Color.FromArgb(255, 8, 8, 9), 1)) g.DrawPath(pen, p);
            }
            using (var p = new Pen(Color.FromArgb(on ? 140 : 50, 255, 255, 255), 1))
                g.DrawLine(p, cap.Left + 4 * s, cap.Top + 1.5f, cap.Right - 4 * s, cap.Top + 1.5f);
            using (var p = new Pen(Color.FromArgb(on ? 70 : 50, 0, 0, 0), Math.Max(1, s)))
                foreach (var dy in new[] { -6f, -3.5f, 3.5f, 6f })
                    g.DrawLine(p, cap.Left + 8 * s, cy + dy * s, cap.Right - 8 * s, cy + dy * s);
            using (var p = new Pen(on ? (muted ? Bad : C(0x17181b)) : C(0x3c3f45), Math.Max(2, 2 * s)))
                g.DrawLine(p, cap.Left + 3 * s, cy, cap.Right - 3 * s, cy);
        }
        void DrawReadout(Graphics g)
        {
            var sf = StringFormat.GenericTypographic;
            bool on = link != null;
            string num = !on ? "—" : level <= -Proto.MaxAtt ? "−∞" : level == 0 ? "0" : "−" + (-level);
            string unit = on ? " dB" : "";
            using (var sfu = (StringFormat)sf.Clone())
            {
                sfu.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
                float wn = g.MeasureString(num, fBig, PointF.Empty, sfu).Width;
                float wu = unit == "" ? 0 : g.MeasureString(unit, fUnit, PointF.Empty, sfu).Width;
                float x = ClientSize.Width / 2f - (wn + wu) / 2;
                float baseline = rReadout.Top + rReadout.Height / 2 + fBig.Size * 0.36f;
                var numCol = !on ? Faint : muted ? Dim : Ink;
                using (var b = new SolidBrush(numCol)) g.DrawString(num, fBig, b, x, baseline - Ascent(fBig), sfu);
                if (unit != "")
                    using (var b = new SolidBrush(Dim)) g.DrawString(unit, fUnit, b, x + wn, baseline - Ascent(fUnit), sfu);
            }
        }
        static float Ascent(Font f)
        {
            var ff = f.FontFamily;
            return f.Size * ff.GetCellAscent(f.Style) / ff.GetEmHeight(f.Style);
        }
        void DrawMute(Graphics g)
        {
            bool on = link != null, hot = on && hover == Hit.Mute;
            float rad = rMute.Height / 2;
            if (on && muted)
            {
                Fill(g, rMute, rad, hot ? C(0xf47075) : Bad);
                Write(g, "MUTED", fButton, Color.White, rMute, StringAlignment.Center);
            }
            else
            {
                if (hot) Fill(g, rMute, rad, C(0x26282d));
                var r = rMute; r.Inflate(-0.5f, -0.5f);
                Stroke(g, r, rad, on ? C(0x3d4048) : C(0x2a2c31), 1);
                Write(g, "MUTE", fButton, !on ? Faint : hot ? Ink : Dim, rMute, StringAlignment.Center);
            }
        }
        void DrawSheet(Graphics g)
        {
            using (var b = new LinearGradientBrush(new PointF(0, rSheet.Bottom), new PointF(0, rSheet.Bottom + 10 * s), Color.FromArgb(110, 0, 0, 0), Color.FromArgb(0, 0, 0, 0)))
                g.FillRectangle(b, 0, rSheet.Bottom, rSheet.Width, 10 * s);
            using (var b = new SolidBrush(SheetBg)) g.FillRectangle(b, rSheet.X, rSheet.Y - 36 * s, rSheet.Width, rSheet.Height + 36 * s);
            using (var p = new Pen(Hair, 1)) g.DrawLine(p, 0, rSheet.Bottom - 0.5f, rSheet.Width, rSheet.Bottom - 0.5f);
            DrawField(g, rHost, tbHost.Focused);
            DrawField(g, rPort, tbPort.Focused);
            bool fHot = hover == Hit.Find && !finding;
            Fill(g, rFind, 5 * s, fHot ? C(0x2c2e34) : SheetBg);
            var fr = rFind; fr.Inflate(-0.5f, -0.5f);
            Stroke(g, fr, 5 * s, Edge, 1);
            Write(g, finding ? "Finding…" : "Find", fButton, finding ? Faint : Ink, rFind, StringAlignment.Center);
            bool cHot = hover == Hit.Connect && !connecting;
            Fill(g, rConnect, 5 * s, connecting ? C(0x6b5130) : cHot ? AccentHot : Accent);
            Write(g, connecting ? "Connecting…" : "Connect", fButton, connecting ? C(0xc9b494) : C(0x1c1306), rConnect, StringAlignment.Center);
            if (message != "")
                using (var sf = new StringFormat { Trimming = StringTrimming.EllipsisWord })
                using (var b = new SolidBrush(tone == Tone.Error ? Bad : Dim))
                    g.DrawString(message, fSmall, b, rMsg, sf);
        }
        void DrawField(Graphics g, RectangleF r, bool focused)
        {
            Fill(g, r, 5 * s, FieldBg);
            var o = r; o.Inflate(-0.5f, -0.5f);
            Stroke(g, o, 5 * s, focused ? Accent : Edge, 1);
        }
        Hit HitTest(Point p)
        {
            if (rGear.Contains(p)) return Hit.Gear;
            if (sheetOpen)
            {
                if (rFind.Contains(p)) return Hit.Find;
                if (rConnect.Contains(p)) return Hit.Connect;
                if (rSheet.Contains(p) || p.Y < rSheet.Y) return Hit.Sheet;
            }
            if (rMute.Contains(p)) return Hit.Mute;
            if (rFader.Contains(p) && Math.Abs(p.X - cx) <= capW / 2 + 8 * s) return Hit.Fader;
            return Hit.None;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != MouseButtons.Left) return;
            var h = HitTest(e.Location);
            pressed = h;
            if (h != Hit.Sheet && ActiveControl is TextBox) ActiveControl = null;
            if (h == Hit.Fader && link != null)
            {
                float cy = YOf(level);
                if (Math.Abs(e.Y - cy) <= capH / 2 + 2 * s) grab = e.Y - cy;
                else SetLevel(level + (e.Y < cy ? 1 : -1), true);
            }
            else if (h == Hit.None && sheetOpen && link != null) ToggleSheet();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (grab.HasValue)
            {
                SetLevel(VOf(e.Y - grab.Value), true);
                return;
            }
            var h = HitTest(e.Location);
            if (h != hover)
            {
                hover = h;
                Invalidate();
            }
            bool click = h == Hit.Gear || (h == Hit.Find && !finding) || (h == Hit.Connect && !connecting) || ((h == Hit.Mute || h == Hit.Fader) && link != null);
            Cursor = click ? Cursors.Hand : Cursors.Default;
            var want = e.Y < 36 * s && !rGear.Contains(e.Location) ? TipText() : null;
            if (want != tipText)
            {
                tipText = want;
                tip.SetToolTip(this, want);
            }
        }
        string TipText()
        {
            var t = link != null ? deviceName + " — " + connectedTo : stateText;
            return message != "" && message != t ? t + "\n" + message : t;
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            var was = pressed;
            pressed = Hit.None;
            if (grab.HasValue) { grab = null; return; }
            if (e.Button != MouseButtons.Left || HitTest(e.Location) != was) return;
            if (was == Hit.Gear) ToggleSheet();
            else if (was == Hit.Find) Find();
            else if (was == Hit.Connect) Connect();
            else if (was == Hit.Mute) ToggleMute();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (hover != Hit.None) { hover = Hit.None; Invalidate(); }
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (link == null) return;
            wheelAcc += e.Delta;
            int steps = wheelAcc / 120;
            wheelAcc -= steps * 120;
            if (steps != 0) SetLevel(level + steps, true);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape && sheetOpen) { ToggleSheet(); return true; }
            if (!(ActiveControl is TextBox))
            {
                switch (keyData)
                {
                    case Keys.Up: Nudge(1); return true;
                    case Keys.Down: Nudge(-1); return true;
                    case Keys.PageUp: Nudge(5); return true;
                    case Keys.PageDown: Nudge(-5); return true;
                    case Keys.M: ToggleMute(); return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        void ToggleSheet()
        {
            sheetOpen = !sheetOpen;
            DoLayout();
            if (sheetOpen && tbHost.Text == "") tbHost.Focus();
            if (!sheetOpen) ActiveControl = null;
            Invalidate();
        }
        void OpenSheet()
        {
            if (!sheetOpen) ToggleSheet();
        }
        void Say(string state, string msg, Tone t)
        {
            stateText = state;
            message = msg;
            tone = t;
            tipText = null;
            DoLayout();
            Invalidate();
        }
        void Post(Action a)
        {
            try { if (IsHandleCreated && !IsDisposed) BeginInvoke(a); }
            catch (InvalidOperationException) { }
        }
        public void ShowError(Exception e)
        {
            try
            {
                Say(link != null ? "Connected" : "Not connected", "Unexpected error: " + e.Message, Tone.Error);
                OpenSheet();
            }
            catch { }
        }
        void Nudge(int step)
        {
            if (link != null) SetLevel(level + step, true);
        }
        void SetLevel(int v, bool user)
        {
            v = Math.Max(-Proto.MaxAtt, Math.Min(0, v));
            if (v == level) return;
            level = v;
            Invalidate();
            if (user && link != null)
            {
                lastUserTick = Environment.TickCount;
                if (!sendTimer.Enabled) sendTimer.Start();
            }
        }
        void SendNow()
        {
            int att = -level;
            if (link == null || att == lastSent) return;
            try
            {
                link.Request("set_volume", Proto.MainId, att);
                lastSent = att;
            }
            catch (Exception e)
            {
                Lost("Lost connection: " + e.Message);
            }
        }
        void ToggleMute()
        {
            if (link == null) return;
            muted = !muted;
            Invalidate();
            try { link.Request("set_mute", Proto.MainId, muted ? 1 : 0); }
            catch (Exception e) { Lost("Lost connection: " + e.Message); }
        }
        void Find()
        {
            if (finding) return;
            finding = true;
            if (link == null) Say("Searching…", "Looking for the Orion on the network…", Tone.Busy);
            else Invalidate();
            Run(() =>
            {
                Dictionary<string, object> svc;
                try
                {
                    svc = Finder.Pick(Finder.Discover(3000));
                }
                catch (SocketException e)
                {
                    Post(() => FindFailed("Automatic search couldn't run (" + e.Message + "). Type the server and port, then click Connect."));
                    return;
                }
                Post(() => Found(svc));
            }, () => finding = false);
        }
        void Found(Dictionary<string, object> svc)
        {
            finding = false;
            if (svc == null)
            {
                FindFailed("Couldn't find the Orion automatically. Windows Firewall may be blocking this app; allow it on private networks, or type the server and port, then click Connect.");
                return;
            }
            var ip = Proto.Str(svc, "ip");
            tbHost.Text = ip != "" ? ip : "127.0.0.1";
            tbPort.Text = Proto.Str(svc, "port");
            var name = Proto.Str(svc, "name");
            if (name != "") deviceName = name;
            Connect();
        }
        void FindFailed(string msg)
        {
            finding = false;
            Say(link != null ? stateText : "Not connected", msg, Tone.Error);
            OpenSheet();
        }
        void Run(Action work, Action onError)
        {
            var t = new Thread(() =>
            {
                try { work(); }
                catch (Exception e) { Post(() => { onError(); ShowError(e); }); }
            });
            t.IsBackground = true;
            t.Start();
        }
        void Connect()
        {
            var host = tbHost.Text.Trim();
            int port;
            if (!int.TryParse(tbPort.Text.Trim(), NumberStyles.None, CultureInfo.InvariantCulture, out port) || port <= 0 || port >= 65536)
            {
                Say("Not connected", "Enter a server address and a port number, or click Find.", Tone.Error);
                OpenSheet();
                return;
            }
            if (host == "")
            {
                Say("Not connected", "Enter a server address, or click Find.", Tone.Error);
                OpenSheet();
                return;
            }
            Disconnect();
            int my = ++linkId;
            connecting = true;
            Say("Connecting…", "Connecting to " + host + ":" + port + "…", Tone.Busy);
            Run(() => Worker(my, host, port), () => connecting = false);
        }
        void Worker(int my, string host, int port)
        {
            var where = host + ":" + port;
            Link l;
            try
            {
                l = new Link(host, port);
            }
            catch (Exception e)
            {
                Post(() => ConnectFailed(my, "Couldn't connect to " + where + " (" + e.Message + ")."));
                return;
            }
            int vol;
            bool mute, note, ok;
            try
            {
                ok = l.ReadState(3000, out vol, out mute, out note);
            }
            catch (Exception e)
            {
                l.Dispose();
                Post(() => ConnectFailed(my, "Connected to " + where + " but it failed: " + e.Message));
                return;
            }
            if (!ok)
            {
                l.Dispose();
                var msg = note
                    ? where + " is the Antelope server's general port. It doesn't control the Orion; the Orion has its own port. Click Find to get it."
                    : "Connected to " + where + " but no volume status came back. Check the port, or click Find.";
                Post(() => ConnectFailed(my, msg));
                return;
            }
            Post(() => Connected(my, l, vol, mute, host, port));
            while (true)
            {
                object m;
                try
                {
                    m = l.Read();
                }
                catch (Exception e)
                {
                    var err = e.Message;
                    Post(() => { if (my == linkId) Lost("Connection lost (" + err + "). Click Connect to retry."); });
                    return;
                }
                var v = Proto.FindKey(m, "volume_main");
                if (v == null) continue;
                int nv = Proto.ToInt(v);
                bool nm = Proto.ToInt(Proto.FindKey(m, "mute_main")) != 0;
                Post(() => OnState(my, nv, nm));
            }
        }
        void ConnectFailed(int my, string msg)
        {
            if (my != linkId) return;
            connecting = false;
            Say("Not connected", msg, Tone.Error);
            OpenSheet();
        }
        void Connected(int my, Link l, int vol, bool mute, string host, int port)
        {
            if (my != linkId) { l.Dispose(); return; }
            link = l;
            connecting = false;
            connectedTo = host + ":" + port;
            settings["host"] = host;
            settings["port"] = port;
            settings["name"] = deviceName;
            Store.Save(settings);
            level = Math.Max(-Proto.MaxAtt, Math.Min(0, -vol));
            muted = mute;
            lastSent = vol;
            if (sheetOpen) ToggleSheet();
            Say("Connected", "", Tone.Ok);
        }
        void OnState(int my, int vol, bool mute)
        {
            if (my != linkId || link == null) return;
            if (unchecked(Environment.TickCount - lastUserTick) > 500 && !sendTimer.Enabled && grab == null)
            {
                SetLevel(-vol, false);
                lastSent = vol;
            }
            muted = mute;
            Invalidate();
        }
        void Lost(string msg)
        {
            Disconnect();
            Say("Connection lost", msg, Tone.Error);
            OpenSheet();
        }
        void Disconnect()
        {
            if (link != null)
            {
                link.Dispose();
                link = null;
            }
            sendTimer.Stop();
            grab = null;
            Invalidate();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            var b = WindowState == FormWindowState.Normal ? Bounds : RestoreBounds;
            settings["x"] = b.X;
            settings["y"] = b.Y;
            settings["w"] = b.Width;
            settings["h"] = b.Height;
            Store.Save(settings);
            linkId++;
            Disconnect();
            base.OnFormClosing(e);
        }
    }
    static class Program
    {
        [DllImport("user32.dll")] static extern bool SetProcessDpiAwarenessContext(IntPtr value);
        [DllImport("user32.dll")] static extern bool SetProcessDPIAware();
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                try { SetProcessDpiAwarenessContext(new IntPtr(-4)); }
                catch { try { SetProcessDPIAware(); } catch { } }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            var form = new MainForm();
            Application.ThreadException += (o, e) => form.ShowError(e.Exception);
            Application.Run(form);
        }
    }
}
