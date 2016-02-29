using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace Pineapple_AdminWeb.Helpers
{
    public class AzureBlob
    {
        CloudStorageAccount account;
        CloudBlobClient client;
        CloudBlobContainer contenedor;
        public AzureBlob()
        {
            var conString = WebConfigurationManager.AppSettings["PicStorage"];
            account = CloudStorageAccount.Parse(conString);
            client = account.CreateCloudBlobClient();
            contenedor = client.GetContainerReference("img");
            if (contenedor.CreateIfNotExists())
            {
                var permisos = contenedor.GetPermissions();
                permisos.PublicAccess = BlobContainerPublicAccessType.Container;
                contenedor.SetPermissions(permisos);
            }

        }
        public async Task<string> GuardarImagen(HttpPostedFileBase imagen)
        {
            if (true)
            {
                try
                {
                    string nombreimagen = string.Format("{0}{1}.{2}", Guid.NewGuid(), Path.GetFileNameWithoutExtension(imagen.FileName), Path.GetExtension(imagen.FileName));
                    var blob = contenedor.GetBlockBlobReference(nombreimagen);
                    blob.Properties.ContentType = imagen.ContentType;
                    await blob.UploadFromStreamAsync(imagen.InputStream);
                    return blob.Uri.ToString();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            else
                throw new ArgumentException();

        }
    }
}
