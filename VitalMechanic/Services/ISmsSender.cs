using System.Threading.Tasks;

namespace VitalMechanic.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
