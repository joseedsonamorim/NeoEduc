using Convai.Scripts.Runtime.LoggerSystem;
using UnityEngine;

namespace Convai.Scripts.Runtime.Addons
{
    public class NetworkReachabilityChecker : MonoBehaviour
    {
        private void Start()
        {
            // Variable to store the debug text for network reachability status
            string networkStatusDebugText = "";

            switch (Application.internetReachability)
            {
                // Check the current internet reachability status
                case NetworkReachability.NotReachable:
                    // If the device is not reachable over the internet, set debug text and send a notification.
                    networkStatusDebugText = "Inacessível";
                    NotificationSystemHandler.Instance.NotificationRequest(NotificationType.NetworkReachabilityIssue);
                    break;
                case NetworkReachability.ReachableViaCarrierDataNetwork:
                    // Reachable via mobile data network
                    networkStatusDebugText = "Acessível através da rede de dados da operadora";
                    break;
                case NetworkReachability.ReachableViaLocalAreaNetwork:
                    // Reachable via local area network
                    networkStatusDebugText = "Acessível via rede local";
                    break;
            }

            // Log the network reachability status for debugging
            ConvaiLogger.Info("Acessibilidade da rede: " + networkStatusDebugText, ConvaiLogger.LogCategory.Character);
        }
    }
}