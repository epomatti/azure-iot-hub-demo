using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Provisioning.Service;

namespace EnrollmentApp
{
    class Program
    {
        private static string ProvisioningConnectionString = "HostName=happybeerhub-us.azure-devices.net;DeviceId=test-device-01;SharedAccessKey=tawpddfqUt3EHZg9a5tUzQ5fjros7zMhKsZbmuXzwXE=";
        private static string EnrollmentGroupId = "test";
        private static string X509RootCertPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"key.pfx");        

        static void Main(string[] args)
        {
            RunSample().GetAwaiter().GetResult();
            Console.WriteLine("\nHit <Enter> to exit ...");
            Console.ReadLine();
        }

        public static async Task RunSample()
        {
            Console.WriteLine("Starting sample...");

            using (ProvisioningServiceClient provisioningServiceClient =
                    ProvisioningServiceClient.CreateFromConnectionString(ProvisioningConnectionString))
            {
                #region Create a new enrollmentGroup config
                Console.WriteLine("\nCreating a new enrollmentGroup...");
                var certificate = new X509Certificate2(X509RootCertPath);
                Attestation attestation = X509Attestation.CreateFromRootCertificates(certificate);
                EnrollmentGroup enrollmentGroup =
                        new EnrollmentGroup(
                                EnrollmentGroupId,
                                attestation)
                        {
                            ProvisioningStatus = ProvisioningStatus.Enabled
                        };
                Console.WriteLine(enrollmentGroup);
                #endregion

                #region Create the enrollmentGroup
                Console.WriteLine("\nAdding new enrollmentGroup...");
                EnrollmentGroup enrollmentGroupResult =
                    await provisioningServiceClient.CreateOrUpdateEnrollmentGroupAsync(enrollmentGroup).ConfigureAwait(false);
                Console.WriteLine("\nEnrollmentGroup created with success.");
                Console.WriteLine(enrollmentGroupResult);
                #endregion

            }
        }
    }
}
