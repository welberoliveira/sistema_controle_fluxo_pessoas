
Imports System.IO
Imports System.Threading.Tasks
Imports Dropbox.Api
Imports Dropbox.Api.Files
Imports System.Text


Partial Class dropbox_
    Inherits System.Web.UI.Page

    'dropbox
    Private pasta As String = ""
    Private nome_arquivo As String
    Private fileupload_name As String = ""
    Private byteArray As Byte()
    Private stream1 As System.IO.MemoryStream
    Private dbx As DropboxClient


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim caminho_arquivo As String = Server.MapPath("/temp/" + FileUpload1.FileName)
        nome_arquivo = FileUpload1.FileName
        FileUpload1.PostedFile.SaveAs(caminho_arquivo)

        byteArray = System.IO.File.ReadAllBytes(caminho_arquivo)
        stream1 = New System.IO.MemoryStream(byteArray)

        'subir o aruqivo para o Dropbox
        Dim t As Task = New Task(AddressOf Run2)
        ' Inicia a tarefa
        t.Start()
        Dim texto As String = ""

        While Not t.IsCompleted
            'If t.Status.ToString <> "WaitingToRun" And t.Status.ToString <> "Running" And t.Status.ToString <> "RanToCompletion" Then
            texto += t.Status.ToString + "<br>"
            'End If

        End While
        Response.Write(texto)

        'deletar o arquivo do servidor para manter somente do dropbox
        System.IO.File.Delete(caminho_arquivo)



        'Dim I As New DropboxClient("pGFlTCSEofAAAAAAAAAAC6l3DBLRQAYPbzaMzjUWdlhIwAHvB8yoUktTZtrGzW_n")

        'Dim FilePath As String

        'FilePath = FileUpload1.ToString
        'FilePath = FileUpload1.FileName
        'FilePath = Server.MapPath(FileUpload1.FileName)
        'FilePath = Convert.ToString(FileUpload1.PostedFile.FileName)


        'Dim _path As String
        '_path = "/pasta2/" & Path.GetFileName(FilePath)
        'Try

        '    Dim rawData = File.ReadAllBytes("C:\Users\user\Downloads\" + FilePath)
        '    Dim str = System.Text.Encoding.Default.GetString(rawData)
        '    Using mem = New MemoryStream(Encoding.UTF8.GetBytes(str))
        '        'Dim Up = I.Files.UploadAsync(_path, body:=mem)
        '        Dim Up = I.Files.UploadAsync(_path, WriteMode.Overwrite.Instance, body:=mem)
        '        MsgBox("Successfully Uploaded")
        '    End Using

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    'Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    Dim folderPath As String = Server.MapPath("~/Files/")

    '    'Check whether Directory (Folder) exists.
    '    If Not Directory.Exists(folderPath) Then
    '        'If Directory (Folder) does not exists. Create it.
    '        Directory.CreateDirectory(folderPath)
    '    End If

    '    'Save the File to the Directory (Folder).
    '    FileUpload1.SaveAs(folderPath & Path.GetFileName(FileUpload1.FileName))

    '    'Display the success message.
    '    Response.Write(Path.GetFileName(FileUpload1.FileName) + " has been uploaded.")
    'End Sub








    'enviar aquivo para o servidor e depois para o dropbox

    Async Sub Run2()
        Using dbx = New DropboxClient("pGFlTCSEofAAAAAAAAAAC6l3DBLRQAYPbzaMzjUWdlhIwAHvB8yoUktTZtrGzW_n")
            Dim resultado = Await dbx.Files.UploadAsync("/pasta2/" & nome_arquivo, WriteMode.Overwrite.Instance, body:=stream1)
        End Using
    End Sub
End Class
