# Using Certificates For API Authentication In .NET 5

### Project based on this Article: https://www.c-sharpcorner.com/article/using-certificates-for-api-authentication-in-net-5/

## Instructions

```sh
1. Generate Server Certificate

	New-SelfSignedCertificate -DnsName "localhost", "localhost" -CertStoreLocation "cert:\LocalMachine\My" -NotAfter (Get-Date).AddYears(10) -FriendlyName "CAlocalhostSTK" -KeyUsageProperty All -KeyUsage CertSign, CRLSign, DigitalSignature

2. Copy the Thumbprint generated:

	BFB782C7FCEAC5F76552FABFCC2F5AC0A3264218
	
3. Set a password:

	$mypwd = ConvertTo-SecureString -String "Server123" -Force -AsPlainText
	
4. Generate the PFX file for the certificate using the Thumbprint generated previously:

	Get-ChildItem -Path cert:\localMachine\my\BFB782C7FCEAC5F76552FABFCC2F5AC0A3264218 | Export-PfxCertificate -FilePath "C:\Projects\CertificatesForAuthentication\CertAuth_SofttekMachine\Certs\cacertStk.pfx" -Password $mypwd
	
5. Generate the Client Certificate (using the Thumbprint generated previously)

	$rootcert = ( Get-ChildItem -Path cert:\LocalMachine\My\BFB782C7FCEAC5F76552FABFCC2F5AC0A3264218 )
	
6. Command to generate the Client Certificate:

	New-SelfSignedCertificate -certstorelocation cert:\localmachine\my -dnsname "localhost" -Signer $rootcert -NotAfter (Get-Date).AddYears(10) -FriendlyName "ClientlocalhostSTK"

8. Compy the Client Thumbprint generated:

	5623F37CA37CE72EEF31592177F33C01D3B9FE9C

9. Set a password: 

	$mypwd = ConvertTo-SecureString -String "Client123" -Force -AsPlainText

10. Generate the PFX file for the Client Certificate using the Thumbprint generated previously:

	Get-ChildItem -Path cert:\localMachine\my\5623F37CA37CE72EEF31592177F33C01D3B9FE9C | Export-PfxCertificate -FilePath "C:\Projects\CertificatesForAuthentication\CertAuth_SofttekMachine\Certs\clientcertSTK.pfx" -Password $mypwd

11. Set the Thumbprint from Client Certificate in the array allowedThumbprints (class CertificateValidation.cs)

12. Install the Server Certificate.

13. Attach the Client Certificate

```