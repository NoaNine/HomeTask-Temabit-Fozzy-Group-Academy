using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileEvolution
{
    class LandlinePhone : IElectricalSignal
    {
        public void ConversionSounWaves()
        {

        }
        public void TransmissionSignal()
        {

        }
        public void RecivingSignal()
        {

        }
    }
    class MobilePhoneWithRadio : IRadioSignal, IRadio
    {
        public void RecivingAccess()
        {

        }
        public void Listening()
        {

        }
        public void RecivingSignal()
        {

        }
        public void ChangeRange()
        {

        }
    }
    // далее для уменьшения кода использовались только интерфейсы особенностей
    class MobilePhoneWithSMS : ISms
    {
        public void SendSms()
        {

        }
        public void ReceiveSms()
        {

        }
    }
    class MobilePhoneWithBlackDisplay :IMediable
    {
        public void PlayMusic()
        {

        }
        public void PlayGames()
        {

        }
    }
    class MobilePhoneWithColorDisplay : ICamera
    {
        public void TakePhoto()
        {

        }
        public void TakeVideo()
        {

        }
    }
    class Iphone : ITouchScreen
    {
        public void CaptureSignal()
        {

        }
    }
    class GoogleGlass : IDisplay, ICamera
    {
        public void OutputInformation()
        {

        }
        public void TakePhoto()
        {

        }
        public void TakeVideo()
        {

        }
    }
    class SmartWatch : IWatchTime, IRateMeterHeart
    {
        public void ShowTime()
        {

        }
        public void RateMeterHeart()
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
        }
    }
}
