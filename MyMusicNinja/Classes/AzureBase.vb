Imports System.IO
Imports Microsoft.WindowsAzure.Storage



Public Class AzureBase
    Public StorageAccount As String = "mymusicninja"
    Public AzureKey As String = "8n3GHQqikvKTf3vel86M5xfJeWUtwJyiqDyR/J+A/w4wIDj6Gwf+twF6I2/4Nd2dQ92mjniP+QKHqvhJpmvUkw=="

    Public Function CreateAzureBlob(AzureInfo As AzurePiecePart, FolderPath As String) As Boolean
        Try
            Dim auth1 As New Auth.StorageCredentials(StorageAccount, AzureKey)
            Dim cloudAccount As New CloudStorageAccount(auth1, True)
            Dim cloudBlob As Blob.CloudBlobClient = cloudAccount.CreateCloudBlobClient
            Dim cloudContainer As Blob.CloudBlobContainer = cloudBlob.GetContainerReference(AzureInfo.Container)
            cloudContainer.CreateIfNotExists()
            Dim cloudBlobFile As Blob.CloudBlockBlob = cloudContainer.GetBlockBlobReference(AzureInfo.FileID)
            cloudBlobFile.UploadFromFile(FolderPath + AzureInfo.FileName)
            cloudBlobFile.FetchAttributes()
            cloudBlobFile.Metadata.Add("MusicPiecePart_ID", AzureInfo.PiecePartID)
            cloudBlobFile.Properties.ContentType = AzureInfo.MimeType
            cloudBlobFile.SetProperties()
            cloudBlobFile.SetMetadata()
            File.Delete(FolderPath + AzureInfo.FileName)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetAzureBlob(AzureInfo As AzurePiecePart) As String
        Try
            Dim auth1 As New Auth.StorageCredentials(StorageAccount, AzureKey)
            Dim cloudAccount As New CloudStorageAccount(auth1, True)
            Dim cloudBlob As Blob.CloudBlobClient = cloudAccount.CreateCloudBlobClient
            Dim cloudContainer As Blob.CloudBlobContainer = cloudBlob.GetContainerReference(AzureInfo.Container)
            Dim cloudBlobFile As Blob.CloudBlockBlob = cloudContainer.GetBlockBlobReference(AzureInfo.FileID)
            Return cloudBlobFile.Uri.ToString
        Catch ex As Exception
            Return "Error"
        End Try
    End Function
End Class
