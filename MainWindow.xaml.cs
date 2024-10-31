using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection.Metadata;

namespace DocumentManagement
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadDocument();
        }

        private void LoadDocument()
        {
            Document document = new Document();

            Section section1 = new Section("Introduction");
            section1.Add(new Paragraph("This is the introduction paragraph."));

            Section section2 = new Section("Main Content");
            section2.Add(new Paragraph("This is the first paragraph of the main content."));
            section2.Add(new Paragraph("This is the second paragraph of the main content."));

            Section subsection = new Section("Subsection");
            subsection.Add(new Paragraph("This is a paragraph in the subsection."));

            section2.Add(subsection);

            document.AddSection(section1);
            document.AddSection(section2);

            // Отображение документа в ListBox
            DocumentListBox.ItemsSource = document.Display();
        }
    }
}