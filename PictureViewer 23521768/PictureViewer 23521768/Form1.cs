namespace PictureViewer_23521768
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeListView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in openFileDialog.FileNames)
                    {
                        // Thêm ?nh vào ImageList và ListView
                        Image img = Image.FromFile(file);
                        listView1.LargeImageList.Images.Add(img);
                        listView1.Items.Add(new ListViewItem(Path.GetFileName(file), listView1.LargeImageList.Images.Count - 1));
                    }
                }
            }
        }

      
        private void InitializeListView()
        {
            listView1.MultiSelect = false;
            listView1.View = View.LargeIcon;

            listView1.LargeImageList = new ImageList();
            listView1.LargeImageList.ImageSize = new Size(130, 100);

            pictureBox1.Size = new Size(524, 342);
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];
                pictureBox1.Image = listView1.LargeImageList.Images[selectedItem.ImageIndex];
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }

}
