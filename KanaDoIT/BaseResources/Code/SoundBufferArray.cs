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
using System.Windows.Resources;
using System.IO;

namespace Arbaureal.KanaDoIT
{
    public class SoundBufferArray
    {
        int nCurrentSoundIndex;
        List<MediaElement> listSounds;

        public SoundBufferArray(Uri soundUri, int nBufferSize, Panel LayoutRoot)
        {
            nCurrentSoundIndex = 0;
            listSounds = new List<MediaElement>(nBufferSize);

            StreamResourceInfo sri = Application.GetResourceStream(soundUri);

            if (sri != null && sri.Stream != null)
            {
                Byte[] arr = new Byte[sri.Stream.Length];
                sri.Stream.Read(arr, 0, (int)sri.Stream.Length);

                for (int index = 0; index < nBufferSize; ++index)
                {
                    MemoryStream memstream = new MemoryStream(arr);
                    MediaElement media = new MediaElement();
                    media.SetSource(memstream);
                    media.AutoPlay = false;
                    LayoutRoot.Children.Add(media);
                    listSounds.Add(media);
                }
            }
        }

        public void PlaySoundFromBuffer()
        {
            if (nCurrentSoundIndex >= listSounds.Count)
            {
                nCurrentSoundIndex = 0;
            }

            listSounds[nCurrentSoundIndex].Stop();
            listSounds[nCurrentSoundIndex].Play();

            ++nCurrentSoundIndex;
        }
    }
}
