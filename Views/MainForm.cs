using System.Windows.Forms;
using dotnetClientDemo.ViewModels;
using dotnetClientDemo.Services;

namespace dotnetClientDemo.Views
{
    public class MainForm : Form
    {
        // Declare controls here, such as buttons and text boxes
        private Button myButton;
        private Button my2Button;
        private TextBox myTextBox;

        public String? demoResponse;
        
        // test stuff
        private ApiService _apiService;

        // Declare ViewModel instance
        private MyViewModel viewModel;

         private async void MyButton_Click(object sender, EventArgs e)
        {
            // This code will execute when the button is clicked

            ApiService apiService = new ApiService();
            var response = await apiService.GetDataFromApi( "http://localhost:5000", "/users/test");
            // MessageBox.Show(response);

            myTextBox.Text = response;
        }
        
        private async void My2Button_Click(object sender, EventArgs e)
        {
            // This code will execute when the button is clicked

            ApiService apiService = new ApiService();
            var response = await apiService.GetDataFromApi( "http://localhost:5000", "/users/test");
            
            myTextBox.Text = response;
        }

        public MainForm()
        {
            // this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Demo dotnet Client";
            
            // Initialize controls
            this.myButton = new Button();
            this.my2Button = new Button();
            this.myTextBox = new TextBox();
            
            // Set control properties, such as text and location
            this.myButton.Text = "Call express api";
            this.my2Button.Text = "Call dotnet api";
            myTextBox.Text = "API responses will be displayed here";

            this.myButton.Location = new Point(50, 50);
            this.my2Button.Location = new Point(250, 50);
            this.myTextBox.Location = new Point(50, 110);
            
            this.myButton.Size = new Size(150, 50); // width: 100, height: 50
            this.my2Button.Size = new Size(150, 50); // width: 100, height: 50
            this.myTextBox.Size = new Size(300, 150);
            myTextBox.Multiline = true;
             
            // Add controls to form
            this.Controls.Add(this.myButton);
            this.Controls.Add(this.my2Button);
            this.Controls.Add(this.myTextBox);
            
            // Add an event handler for the Click event of the buttons
            myButton.Click += new EventHandler(MyButton_Click);
            my2Button.Click += new EventHandler(My2Button_Click);
            
            // Instantiate ViewModel
            this.viewModel = new MyViewModel();
            
            
            // Set up data bindings between controls and ViewModel properties
            // this.myButton.DataBindings.Add("Enabled", this.viewModel, "IsButtonEnabled");
            // this.myTextBox.DataBindings.Add("Text", this.viewModel, "MyText");
        }
    }
}
