using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileEvolution
{
    public interface IElectricalSignal
    {
        void ConversionSounWaves();
        void TransmissionSignal();
        void RecivingSignal();
    }
    public interface IRadioSignal
    {
        void RecivingAccess();
        void Listening();
    }
    public interface IWatchTime
    {
        void ShowTime();
    }
    public interface ISms
    {
        void SendSms();
        void ReceiveSms();
    }
    public interface IRadio
    {
        void RecivingSignal();
        void ChangeRange();

    }
    public interface IMediable
    {
        void PlayMusic();
        void PlayGames();
    }
    public interface ICamera
    {
        void TakePhoto();
        void TakeVideo();
    }
    public interface ITouchScreen
    {
        void CaptureSignal();
    }
    public interface IDisplay
    {
        void OutputInformation();
    }
    public interface IRateMeterHeart
    {
        void RateMeterHeart();
    }
}
