using System;
using System.Threading.Tasks;
using System.Windows.Media;
using ff14bot;
using ff14bot.AClasses;
using ff14bot.Behavior;
using LlamaLibrary.Logging;
using LlamaLibrary.Memory;
using TreeSharp;

namespace CompanyChest
{
    public class CompanyChest : BotBase
    {
        private static readonly LLogger Log = new LLogger("CompanyChest", Colors.Teal);

        private Composite _root;
        public override string Name => "CompanyChest";
        public override PulseFlags PulseFlags => PulseFlags.All;
        public override bool IsAutonomous => true;
        public override bool RequiresProfile => false;
        public override Composite Root => _root;
        public override bool WantButton { get; } = true;
        private CompanyChestSettings _settings;
        private static bool _isDone = false;

        public override void Initialize()
        {
            OffsetManager.Init();
        }

        public override void OnButtonPress()
        {
            if (_settings == null || _settings.IsDisposed)
            {
                _settings = new CompanyChestSettings();
            }

            try
            {
                _settings.Show();
                _settings.Activate();
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }

        public override void Start()
        {
            _isDone = false;
            _root = new ActionRunCoroutine(r => Run());
        }

        private async Task<bool> Run()
        {
            if (_isDone) return false;

            _isDone = true;
            TreeRoot.Stop("Done fiddling with FC chest.");
            return false;
        }

        public override void Stop()
        {
            _isDone = true;
            _root = null;
        }
    }
}