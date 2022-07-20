using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace WebAppCertsSolution
{
    public class CertificateValidation
    {
        public bool ValidateCertificate(X509Certificate2 clientCertificate)
        {
            string[] allowedThumbprints = {
                "5623F37CA37CE72EEF31592177F33C01D3B9FE9C"
            };
            if (allowedThumbprints.Contains(clientCertificate.Thumbprint))
            {
                return true;
            }
            return false;
        }
    }
}
