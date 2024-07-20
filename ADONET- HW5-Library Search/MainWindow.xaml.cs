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
using System.Data.SqlClient;
using System.Configuration;


namespace ADONET__HW5_Library_Search
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LibraryContext _context;
        public MainWindow()
        {
            InitializeComponent();
            _context = new LibraryContext();
        }

        private void Search_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Search_ComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string? selectedValue = selectedItem.Content.ToString();

                if (selectedValue == "Authors")
                {
                    LoadAuthors();
                }
                else if (selectedValue == "Themes")
                {
                    LoadThemes();
                }
                else if (selectedValue == "Categories")
                {
                    LoadCategories();
                }
                else
                {
                    Display_ComboBox.Items.Clear();
                }

            }
        }

        private void LoadAuthors()
        {
            var authors = _context.authors.ToList();
            Display_ComboBox.Items.Clear();
            foreach (var author in authors)
            {
                Display_ComboBox.Items.Add(new ComboBoxItem
                {
                    Content = author
                });
            }
        }

        private void LoadThemes()
        {
            var themes = _context.themes.ToList();
            Display_ComboBox.Items.Clear();
            foreach (var theme in themes)
            {
                Display_ComboBox.Items.Add(new ComboBoxItem
                { Content = theme });
            }
        }

        private void LoadCategories()
        {
            var categories = _context.categories.ToList();
            Display_ComboBox.Items.Clear();
            foreach(var category in categories)
            {
                Display_ComboBox.Items.Add(new ComboBoxItem
                {
                    Content = category
                });
            }
        }

        private void Display_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Display_ComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                if (selectedItem.Content is Authors selectedAuthor)
                {
                    LoadBooksByAuthor(selectedAuthor.Id);
                }
                else if (selectedItem.Content is Themes selectedTheme)
                {
                    LoadBooksByTheme(selectedTheme.Id);
                }
                else if (selectedItem.Content is Categories selectedCategory)
                {
                    LoadBooksByCategories(selectedCategory.Id);
                }
            }

        }

        private void LoadBooksByAuthor(int authorId)
        {
            var books = _context.books.Where(b => b.Id_Author == authorId).ToList();
            Display_ListBox.Items.Clear();
            foreach (var book in books)
            {
                Display_ListBox.Items.Add(new ListBoxItem
                {
                    Content = book.Name
                });
            }
        }

        private void LoadBooksByTheme(int themeId)
        {
            var books = _context.books.Where(b => b.Id_Themes == themeId).ToList();
            Display_ListBox.Items.Clear();
            foreach (var book in books)
            {
                Display_ListBox.Items.Add(new ListBoxItem
                {
                    Content = book.Name
                });
            }

        }

        private void LoadBooksByCategories(int categoryId)
        {
            var books = _context.books.Where(b => b.Id_Category == categoryId).ToList();
            Display_ListBox.Items.Clear();
            foreach (var book in books)
            {
                Display_ListBox.Items.Add(new ListBoxItem
                {
                    Content = book.Name
                });
            }

        }
    }
}