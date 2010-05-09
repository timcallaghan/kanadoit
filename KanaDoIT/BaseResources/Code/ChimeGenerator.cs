using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace Arbaureal.KanaDoIT.BaseResources
{
    public enum ChimeSound
    {
        Ab1,
        Ab2,
        C2,
        C3,
        Db2,
        Db3,
        F1,
        F2,
        F3,
        G1,
        G2
    }

    public class ChimeGenerator
    {
        public Dictionary<ChimeSound, SoundBufferArray> Chimes;
        private string BaseSoundPath = @"/BaseResources;component/Music/";
        private Random random;

        public ChimeGenerator(Panel layoutRoot)
        {
            Chimes = new Dictionary<ChimeSound, SoundBufferArray>();

            AddChimeSoundToDictionary(ChimeSound.Ab1, layoutRoot);
            AddChimeSoundToDictionary(ChimeSound.Ab2, layoutRoot);
            AddChimeSoundToDictionary(ChimeSound.C2, layoutRoot);
            AddChimeSoundToDictionary(ChimeSound.C3, layoutRoot);
            AddChimeSoundToDictionary(ChimeSound.Db2, layoutRoot);
            AddChimeSoundToDictionary(ChimeSound.Db3, layoutRoot);
            AddChimeSoundToDictionary(ChimeSound.F1, layoutRoot);
            AddChimeSoundToDictionary(ChimeSound.F2, layoutRoot);
            AddChimeSoundToDictionary(ChimeSound.F3, layoutRoot);
            AddChimeSoundToDictionary(ChimeSound.G1, layoutRoot);
            AddChimeSoundToDictionary(ChimeSound.G2, layoutRoot);

            random = new Random();
        }

        public void PlayRandomChime()
        {
            ChimeSound cs = (ChimeSound)random.Next((int)ChimeSound.G2 + 1);
            Chimes[cs].PlaySoundFromBuffer();
        }

        private void AddChimeSoundToDictionary(ChimeSound cs, Panel layoutRoot)
        {
            Uri soundPath = new Uri(BaseSoundPath + "Chime_" + cs.ToString() + ".mp3", UriKind.Relative);
            SoundBufferArray sba = new SoundBufferArray(soundPath, 3, layoutRoot);
            Chimes[cs] = sba;
        }
    }
}
