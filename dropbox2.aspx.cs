using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using Dropbox.Api;
using System.Text;
using Dropbox.Api.Files;
using System.IO;

public partial class dropbox2 :  System.Web.UI.Page
{
    private static string retorno = "";
    private static string folder = "";
    private static string file = "";
    private static string fileupload_name = "";
    private static byte[] byteArray;
    private static System.IO.MemoryStream stream1;

    private static DropboxClient dbx;

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    static async Task Run()
    {
        using (dbx = new DropboxClient("pGFlTCSEofAAAAAAAAAAC6l3DBLRQAYPbzaMzjUWdlhIwAHvB8yoUktTZtrGzW_n"))
        {
            var full = await dbx.Users.GetCurrentAccountAsync();
            retorno += full.Name.DisplayName + " , " + full.Email + "\n";

            var list = await dbx.Files.ListFolderAsync(string.Empty);

            // show folders then files
            foreach (var item in list.Entries.Where(i => i.IsFolder))
            {
                Console.WriteLine("D  {0}/", item.Name);
                retorno += "D" + item.Name + "/" + "\n";
                folder = item.Name;
            }
            
            //show arquivos
            foreach (var item in list.Entries.Where(i => i.IsFile))
            {
                retorno += "F" + item.AsFile.Size + " , " + item.Name + "\n";
                file = item.Name;
            }

            //download
            using (var response = await dbx.Files.DownloadAsync("/pasta/cavalo.jpeg"))
            {
                //retorno += (await response.GetContentAsStringAsync());
            }

            //upload 
            //byte[] byteArray = System.IO.File.ReadAllBytes(@"C:\Users\user\Downloads\cavalo.jpeg");
            
            
            //var updated = await dbx.Files.UploadAsync("/pasta2/cavalo.jpeg", WriteMode.Overwrite.Instance, body: stream1);
        }
        

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //byteArray = System.IO.File.ReadAllBytes(Path.GetFileName(FileUpload1.FileName));
        //System.IO.MemoryStream stream1 = new System.IO.MemoryStream(byteArray);

        var task = Task.Run((Func<Task>)dropbox2.Run);
        task.Wait();

        Literal1.Text = "<pre>" + retorno + "</pre>";
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        FileUpload2.SaveAs(Server.MapPath("temp") + "//" + FileUpload2.FileName);
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        
        byteArray = System.IO.File.ReadAllBytes(Server.MapPath("temp") + "//cavalo.jpeg");
        stream1 = new System.IO.MemoryStream(byteArray);

        var task = Task.Run((Func<Task>)dropbox2.Run2);
        task.Wait();
        
    }

    static async Task Run2()
    {
        using (dbx = new DropboxClient("pGFlTCSEofAAAAAAAAAAC6l3DBLRQAYPbzaMzjUWdlhIwAHvB8yoUktTZtrGzW_n"))
        {
            var updated = await dbx.Files.UploadAsync("/pasta2/cavalo.jpeg", WriteMode.Overwrite.Instance, body: stream1);
        }
    }
}