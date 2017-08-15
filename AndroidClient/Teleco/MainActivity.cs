using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using System.Linq;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using System.Threading.Tasks;
using System.Net.Http;
using Android.Hardware;

namespace Teleco
{
    [Activity(Label = "Teleco", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button[] buttons;

        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            
            buttons = new Button[] {
                new Button() { Id=Resource.Id.fbx_av, Url="http://192.168.0.203:8081/freebox/AV" },
                new Button() { Id=Resource.Id.fbx_power, Url="http://192.168.0.203:8081/freebox/Power" },
                new Button() { Id=Resource.Id.fbx_1, Url="http://192.168.0.203:8081/freebox/1" },
                new Button() { Id=Resource.Id.fbx_2, Url="http://192.168.0.203:8081/freebox/2" },
                new Button() { Id=Resource.Id.fbx_3, Url="http://192.168.0.203:8081/freebox/3" },
                new Button() { Id=Resource.Id.fbx_4, Url="http://192.168.0.203:8081/freebox/4" },
                new Button() { Id=Resource.Id.fbx_5, Url="http://192.168.0.203:8081/freebox/5" },
                new Button() { Id=Resource.Id.fbx_6, Url="http://192.168.0.203:8081/freebox/6" },
                new Button() { Id=Resource.Id.fbx_7, Url="http://192.168.0.203:8081/freebox/7" },
                new Button() { Id=Resource.Id.fbx_8, Url="http://192.168.0.203:8081/freebox/8" },
                new Button() { Id=Resource.Id.fbx_9, Url="http://192.168.0.203:8081/freebox/9" },
                new Button() { Id=Resource.Id.fbx_0, Url="http://192.168.0.203:8081/freebox/0" },
                new Button() { Id=Resource.Id.fbx_up, Url="http://192.168.0.203:8081/freebox/Up" },
                new Button() { Id=Resource.Id.fbx_down, Url="http://192.168.0.203:8081/freebox/Down" },
                new Button() { Id=Resource.Id.fbx_left, Url="http://192.168.0.203:8081/freebox/Left" },
                new Button() { Id=Resource.Id.fbx_right, Url="http://192.168.0.203:8081/freebox/Right" },
                new Button() { Id=Resource.Id.fbx_back, Url="http://192.168.0.203:8081/freebox/Back" },
                new Button() { Id=Resource.Id.fbx_search, Url="http://192.168.0.203:8081/freebox/Search" },
                new Button() { Id=Resource.Id.fbx_menu, Url="http://192.168.0.203:8081/freebox/Menu" },
                new Button() { Id=Resource.Id.fbx_info, Url="http://192.168.0.203:8081/freebox/Info" },
                new Button() { Id=Resource.Id.fbx_enter, Url="http://192.168.0.203:8081/freebox/Enter" },
                new Button() { Id=Resource.Id.fbx_free, Url="http://192.168.0.203:8081/freebox/Free" },
                new Button() { Id=Resource.Id.fbx_volp, Url="http://192.168.0.203:8081/freebox/Vol+", Repeatable=true },
                new Button() { Id=Resource.Id.fbx_volm, Url="http://192.168.0.203:8081/freebox/Vol-", Repeatable=true },
                new Button() { Id=Resource.Id.fbx_mute, Url="http://192.168.0.203:8081/freebox/Mute" },
                new Button() { Id=Resource.Id.fbx_record, Url="http://192.168.0.203:8081/freebox/Record" },
                new Button() { Id=Resource.Id.fbx_chanp, Url="http://192.168.0.203:8081/freebox/Chan+" },
                new Button() { Id=Resource.Id.fbx_chanm, Url="http://192.168.0.203:8081/freebox/Chan-" },
                new Button() { Id=Resource.Id.fbx_rewind, Url="http://192.168.0.203:8081/freebox/Rewind" },
                new Button() { Id=Resource.Id.fbx_play, Url="http://192.168.0.203:8081/freebox/Play/Pause" },
                new Button() { Id=Resource.Id.fbx_forward, Url="http://192.168.0.203:8081/freebox/Fast%20Forward" },

                new Button() { Id=Resource.Id.tv_on, Url="http://192.168.0.203:8081/hdmi/on" },
                new Button() { Id=Resource.Id.tv_standby, Url="http://192.168.0.203:8081/hdmi/standby" },
                new Button() { Id=Resource.Id.tv_free, Url="http://192.168.0.203:8081/hdmi/freebox" },
                new Button() { Id=Resource.Id.tv_rpi, Url="http://192.168.0.203:8081/hdmi/rpi" },

                /*new Button() { Id=Resource.Id.tv_power, IR=new[] { 38000,3965,4001,482,2006,482,2006,482,2006,482,2006,482,1012,482,1012,482,2006,482,1012,482,2006,482,1012,482,2006,482,1012,482,1012,482,1012,482,1012,482,1012,482,2006,482,2006,482,1012,482,2006,482,1012,482,2006,482,1012,482,2006,481,65221 } },
                new Button() { Id=Resource.Id.tv_mute, IR=new[] { 38000,3965,4001,482,2006,482,2006,482,2006,482,2006,482,1012,482,1012,482,2006,482,2006,482,2006,482,2006,482,2006,482,2006,482,1012,482,1012,482,1012,482,1012,482,2006,482,2006,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,481,65221 } },
                //new Button() { Id=Resource.Id.tv_list, IR=new[] { 38000,3965,4001,482,2006,482,2006,482,2006,482,2006,482,2006,482,1012,482,2006,482,1012,482,1012,482,1012,482,2006,482,2006,482,1012,482,1012,482,1012,482,1012,482,1012,482,2006,482,1012,482,2006,482,2006,482,2006,482,1012,482,1012,481,65221 } },
                new Button() { Id=Resource.Id.tv_volumeup, IR=new[] { 38000,3965,4001,482,2006,482,2006,482,2006,482,2006,482,1012,482,1012,482,2006,482,1012,482,2006,482,2006,482,2006,482,1012,482,1012,482,1012,482,1012,482,1012,482,2006,482,2006,482,1012,482,2006,482,1012,482,1012,482,1012,482,2006,481,65221 } },
                new Button() { Id=Resource.Id.tv_volumedown, IR=new[] { 38000,3965,4001,482,2006,482,2006,482,2006,482,2006,482,1012,482,1012,482,2006,482,1012,482,2006,482,2006,482,2006,482,2006,482,1012,482,1012,482,1012,482,1012,482,2006,482,2006,482,1012,482,2006,482,1012,482,1012,482,1012,482,1012,481,65221 } },
                new Button() { Id=Resource.Id.tv_channelup, IR=new[] { 38000,3965,4001,482,2006,482,2006,482,2006,482,2006,482,1012,482,1012,482,2006,482,1012,482,2006,482,2006,482,1012,482,2006,482,1012,482,1012,482,1012,482,1012,482,2006,482,2006,482,1012,482,2006,482,1012,482,1012,482,2006,482,1012,481,65221 } },
                new Button() { Id=Resource.Id.tv_channeldown, IR=new[] { 38000,3965,4001,482,2006,482,2006,482,2006,482,2006,482,1012,482,1012,482,2006,482,1012,482,2006,482,2006,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,2006,482,2006,482,1012,482,2006,482,1012,482,1012,482,2006,482,2006,481,65221 } },
                new Button() { Id=Resource.Id.tv_0, IR=new[] { 38000,3965,4001,482,2006,482,2006,482,2006,482,2006,482,1012,482,1012,482,2006,482,2006,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,2006,482,2006,482,1012,482,1012,482,2006,482,2006,482,2006,482,2006,481,65221 } },
                new Button() { Id=Resource.Id.tv_1, IR=new[] { 38000,3965,4001,482,2006,482,2006,482,2006,482,2006,482,1012,482,1012,482,2006,482,2006,482,1012,482,1012,482,1012,482,2006,482,1012,482,1012,482,1012,482,1012,482,2006,482,2006,482,1012,482,1012,482,2006,482,2006,482,2006,482,1012,481,65221 } },
                new Button() { Id=Resource.Id.tv_2, IR=new[] { 38000,3965,4001,482,2006,482,2006,482,2006,482,2006,482,1012,482,1012,482,2006,482,2006,482,1012,482,1012,482,2006,482,1012,482,1012,482,1012,482,1012,482,1012,482,2006,482,2006,482,1012,482,1012,482,2006,482,2006,482,1012,482,2006,481,65221 } },
                new Button() { Id=Resource.Id.tv_3, IR=new[] { 38000,3965,4001,482,2006,482,2006,482,2006,482,2006,482,1012,482,1012,482,2006,482,2006,482,1012,482,1012,482,2006,482,2006,482,1012,482,1012,482,1012,482,1012,482,2006,482,2006,482,1012,482,1012,482,2006,482,2006,482,1012,482,1012,481,65221 } },
                new Button() { Id=Resource.Id.tv_4, IR=new[] { 38000,3965,4001,482,2006,482,2006,482,2006,482,2006,482,1012,482,1012,482,2006,482,2006,482,1012,482,2006,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,2006,482,2006,482,1012,482,1012,482,2006,482,1012,482,2006,482,2006,481,65221 } },
                new Button() { Id=Resource.Id.tv_5, IR=new[] { 38000,3965,4001,482,2006,482,2006,482,2006,482,2006,482,1012,482,1012,482,2006,482,2006,482,1012,482,2006,482,1012,482,2006,482,1012,482,1012,482,1012,482,1012,482,2006,482,2006,482,1012,482,1012,482,2006,482,1012,482,2006,482,1012,481,65221 } },
                new Button() { Id=Resource.Id.tv_6, IR=new[] { 38000,3965,4001,482,2006,482,2006,482,2006,482,2006,482,1012,482,1012,482,2006,482,2006,482,1012,482,2006,482,2006,482,1012,482,1012,482,1012,482,1012,482,1012,482,2006,482,2006,482,1012,482,1012,482,2006,482,1012,482,1012,482,2006,481,65221 } },
                new Button() { Id=Resource.Id.tv_7, IR=new[] { 38000,3965,4001,482,2006,482,2006,482,2006,482,2006,482,1012,482,1012,482,2006,482,2006,482,1012,482,2006,482,2006,482,2006,482,1012,482,1012,482,1012,482,1012,482,2006,482,2006,482,1012,482,1012,482,2006,482,1012,482,1012,482,1012,481,65221 } },
                new Button() { Id=Resource.Id.tv_8, IR=new[] { 38000,3965,4001,482,2006,482,2006,482,2006,482,2006,482,1012,482,1012,482,2006,482,2006,482,2006,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,2006,482,2006,482,1012,482,1012,482,1012,482,2006,482,2006,482,2006,481,65221 } },
                new Button() { Id=Resource.Id.tv_9, IR=new[] { 38000,3965,4001,482,2006,482,2006,482,2006,482,2006,482,1012,482,1012,482,2006,482,2006,482,2006,482,1012,482,1012,482,2006,482,1012,482,1012,482,1012,482,1012,482,2006,482,2006,482,1012,482,1012,482,1012,482,2006,482,2006,482,1012,481,65221 } },
                new Button() { Id=Resource.Id.tv_back, IR=new[] { 38000,3965,4001,482,2006,482,2006,482,2006,482,2006,482,1012,482,1012,482,2006,482,1012,482,1012,482,2006,482,2006,482,2006,482,1012,482,1012,482,1012,482,1012,482,2006,482,2006,482,1012,482,2006,482,2006,482,1012,482,1012,482,1012,481,65221 } },
                new Button() { Id=Resource.Id.tv_left, IR=new[] { 38000,3965,4001,482,2006,482,2006,482,2006,482,2006,482,1012,482,2006,482,1012,482,2006,482,1012,482,2006,482,2006,482,1012,482,1012,482,1012,482,1012,482,1012,482,2006,482,1012,482,2006,482,1012,482,2006,482,1012,482,1012,482,2006,481,65221 } },
                new Button() { Id=Resource.Id.tv_right, IR=new[] { 38000,3965,4001,482,2006,482,2006,482,2006,482,2006,482,1012,482,2006,482,1012,482,2006,482,1012,482,2006,482,2006,482,2006,482,1012,482,1012,482,1012,482,1012,482,2006,482,1012,482,2006,482,1012,482,2006,482,1012,482,1012,482,1012,481,65221 } },
                new Button() { Id=Resource.Id.tv_up, IR=new[] { 38000,3965,4001,482,2006,482,2006,482,2006,482,2006,482,1012,482,2006,482,1012,482,2006,482,2006,482,1012,482,1012,482,2006,482,1012,482,1012,482,1012,482,1012,482,2006,482,1012,482,2006,482,1012,482,1012,482,2006,482,2006,482,1012,481,65221 } },
                new Button() { Id=Resource.Id.tv_down, IR=new[] { 38000,3965,4001,482,2006,482,2006,482,2006,482,2006,482,1012,482,2006,482,1012,482,2006,482,2006,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,2006,482,1012,482,2006,482,1012,482,1012,482,2006,482,2006,482,2006,481,65221 } },
                new Button() { Id=Resource.Id.tv_setup, IR=new[] { 38000,3965,4001,482,2006,482,2006,482,2006,482,2006,482,1012,482,1012,482,1012,482,1012,482,2006,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,2006,482,2006,482,2006,482,2006,482,1012,482,2006,482,2006,482,2006,481,65221 } },
                new Button() { Id=Resource.Id.tv_ok, IR=new[] { 38000,3965,4001,482,2006,482,2006,482,2006,482,2006,482,2006,482,2006,482,2006,482,2006,482,1012,482,2006,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,2006,482,1012,482,2006,482,2006,481,65221 } },
                new Button() { Id=Resource.Id.tv_exit, IR=new[] { 38000,3965,4001,482,2006,482,2006,482,2006,482,2006,482,1012,482,1012,482,1012,482,1012,482,1012,482,2006,482,2006,482,1012,482,1012,482,1012,482,1012,482,1012,482,2006,482,2006,482,2006,482,2006,482,2006,482,1012,482,1012,482,2006,481,65221 } },
                new Button() { Id=Resource.Id.tv_red, IR=new[] { 38000,3965,4001,482,2006,482,2006,482,2006,482,2006,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,2006,482,2006,482,2006,482,2006,482,2006,482,2006,482,2006,482,2006,481,65221 } },
                new Button() { Id=Resource.Id.tv_green, IR=new[] { 38000,3965,4001,482,2006,482,2006,482,2006,482,2006,482,2006,482,2006,482,2006,482,1012,482,2006,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,2006,482,1012,482,2006,482,2006,482,2006,481,65221 } },
                new Button() { Id=Resource.Id.tv_yellow, IR=new[] { 38000,3965,4001,482,2006,482,2006,482,2006,482,2006,482,2006,482,2006,482,2006,482,1012,482,1012,482,2006,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,2006,482,2006,482,1012,482,2006,482,2006,481,65221 } },
                new Button() { Id=Resource.Id.tv_blue, IR=new[] { 38000,3965,4001,482,2006,482,2006,482,2006,482,2006,482,2006,482,2006,482,1012,482,2006,482,2006,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,1012,482,2006,482,1012,482,1012,482,2006,482,2006,482,2006,481,65221 } },
                */

                new Button() { Id=Resource.Id.kodi_start, Url="http://192.168.0.203:8081/kodi/start" },
                new Button() { Id=Resource.Id.kodi_quit, Url="http://192.168.0.203:8081/kodi/Quit" },
                new Button() { Id=Resource.Id.kodi_up, Url="http://192.168.0.203:8081/kodi/up" },
                new Button() { Id=Resource.Id.kodi_down, Url="http://192.168.0.203:8081/kodi/down" },
                new Button() { Id=Resource.Id.kodi_left, Url="http://192.168.0.203:8081/kodi/left" },
                new Button() { Id=Resource.Id.kodi_right, Url="http://192.168.0.203:8081/kodi/right" },
                new Button() { Id=Resource.Id.kodi_back, Url="http://192.168.0.203:8081/kodi/back" },
                new Button() { Id=Resource.Id.kodi_ok, Url="http://192.168.0.203:8081/kodi/select" },
                new Button() { Id=Resource.Id.kodi_menu, Url="http://192.168.0.203:8081/kodi/contextmenu" },
                new Button() { Id=Resource.Id.kodi_info, Url="http://192.168.0.203:8081/kodi/info" },
                new Button() { Id=Resource.Id.kodi_volumedown, Url="http://192.168.0.203:8081/kodi/volumedown" },
                new Button() { Id=Resource.Id.kodi_volumeup, Url="http://192.168.0.203:8081/kodi/volumeup" },
                new Button() { Id=Resource.Id.kodi_skipprevious, Url="http://192.168.0.203:8081/kodi/skipprevious" },
                new Button() { Id=Resource.Id.kodi_skipnext, Url="http://192.168.0.203:8081/kodi/skipnext" },
                new Button() { Id=Resource.Id.kodi_stepback, Url="http://192.168.0.203:8081/kodi/stepback" },
                new Button() { Id=Resource.Id.kodi_stepforward, Url="http://192.168.0.203:8081/kodi/stepforward" },
                new Button() { Id=Resource.Id.kodi_playpause, Url="http://192.168.0.203:8081/kodi/playpause" },
                new Button() { Id=Resource.Id.kodi_stop, Url="http://192.168.0.203:8081/kodi/stop" },
                new Button() { Id=Resource.Id.kodi_firstpage, Url="http://192.168.0.203:8081/kodi/firstpage" },
                new Button() { Id=Resource.Id.kodi_lastpage, Url="http://192.168.0.203:8081/kodi/lastpage" },
                new Button() { Id=Resource.Id.kodi_pageup, Url="http://192.168.0.203:8081/kodi/pageup" },
                new Button() { Id=Resource.Id.kodi_pagedown, Url="http://192.168.0.203:8081/kodi/pagedown" },
                new Button() { Id=Resource.Id.kodi_prevletter, Url="http://192.168.0.203:8081/kodi/prevletter" },
                new Button() { Id=Resource.Id.kodi_nextletter, Url="http://192.168.0.203:8081/kodi/nextletter" },
            };


            var fbxTeleco = FindViewById<TableLayout>(Resource.Id.fbx_teleco);
            AttachEventHandlers(fbxTeleco);
            var tvTeleco = FindViewById<TableLayout>(Resource.Id.tv_teleco);
            AttachEventHandlers(tvTeleco);
            var kodiTeleco = FindViewById<TableLayout>(Resource.Id.kodi_teleco);
            AttachEventHandlers(kodiTeleco);
        }

        private void AttachEventHandlers(TableLayout fbxTeleco)
        {
            for (int i = 0; i < fbxTeleco.ChildCount; i++)
            {
                var row = fbxTeleco.GetChildAt(i) as TableRow;

                if (row == null) continue;

                for (int j = 0; j < row.ChildCount; j++)
                {
                    var btnView = row.GetChildAt(j) as Android.Widget.Button;
                    btnView.Click += BtnView_Click;
                    btnView.LongClick += BtnView_LongClick;
                }
            }
        }

        private async void BtnView_LongClick(object sender, View.LongClickEventArgs e)
        {
            var button = GetButton(sender);
            while((sender as Android.Widget.Button).Pressed)
            {
                await Act(button);
                await Task.Delay(50);
            }
        }

        private async void BtnView_Click(object sender, EventArgs e)
        {
            var button = GetButton(sender);
            await Act(button);
        }

        private async Task Act(Button button)
        {
            try
            {
                if (button == null) return;
                if (button.Url != null)
                {
                    Log.Info("TELECO", button.Url);
                    var client = new HttpClient();
                    client.Timeout = new TimeSpan(0, 0, 2);
                    await client.GetAsync(button.Url);
                }

                if (button.IR != null)
                {

                    Log.Info("TELECO", "IR" + string.Join(",",button.IR));
                    var s = GetSystemService(Context.ConsumerIrService) as ConsumerIrManager;
                    s.Transmit(button.IR[0], button.IR.Where((source, index) => index != 0).ToArray());
                }
            }
            catch (Exception e)
            {
                Log.Error("TELECO", e.ToString());
            }
        }

        private Button GetButton(object sender)
        {
            var bSender = sender as Android.Widget.Button;  
            foreach(var button in this.buttons)
            {
                
                if(button.Id == bSender.Id)
                {
                    return button;
                }
            }
            return null;
        }
    }
}

