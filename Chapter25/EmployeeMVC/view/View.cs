/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Com.PulpFreePress.Common;

namespace Com.PulpFreePress.View {
  public class View : Form, IView {
    // constants
    private const int WINDOW_HEIGHT = 425;
    private const int WINDOW_WIDTH = 800;
    private const String WINDOW_TITLE = "Employee Management Application ";
    private IEmployee _editing_employee = null;
    private int _editing_employee_index = 0;
    
    //menu fields
    private MenuStrip _ms;
    private ToolStripMenuItem _fileMenu;
    private ToolStripMenuItem _loadMenuItem;
    private ToolStripMenuItem _saveMenuItem;
    private ToolStripMenuItem _exitMenuItem;
    private ToolStripMenuItem _editMenu;
    private ToolStripMenuItem _listMenuItem;
    private ToolStripMenuItem _sortMenuItem;
    private ToolStripMenuItem _newSalariedEmployeeMenuItem;
    private ToolStripMenuItem _newHourlyEmployeeMenuItem;
    private ToolStripMenuItem _editEmployeeMenuItem;
    private ToolStripMenuItem _deleteEmployeeMenuItem;
    
    // fields
    private ViewMode _mode = ViewMode.RESTING;
    private TableLayoutPanel _mainTablePanel;
    private TableLayoutPanel _infoTablePanel;
    private FlowLayoutPanel _buttonPanel;
    private TextBox _mainTextBox;
    private Label _firstNameLabel;
    private Label _middleNameLabel;
    private Label _lastNameLabel;
    private Label _birthdayLabel;
    private Label _genderLabel;
    private Label _hoursWorkedLabel;
    private Label _hourlyRateLabel;
    private Label _salaryLabel;
    private Label _employeeNumberLabel;
    
    private TextBox _firstNameTextBox;
    private TextBox _middleNameTextBox;
    private TextBox _lastNameTextBox;
    private TextBox _hoursWorkedTextBox;
    private TextBox _hourlyRateTextBox;
    private TextBox _salaryTextBox;
    private TextBox _employeeNumberTextBox;
    
    private DateTimePicker _birthdayPicker;
    private GroupBox _genderBox;
    private RadioButton _maleRadioButton;
    private RadioButton _femaleRadioButton;
    private Button _clearButton;
    private Button _submitButton;
    private OpenFileDialog _openFileDialog;
    private SaveFileDialog _saveFileDialog;
    private bool _createMode;
    
    
    // public properties -
    public ViewMode Mode {
      get { return _mode; }
      set { 
        _mode = value;
        this.SetWindowTitleBasedOnMode();
      }
    }
    
    public IEmployee EditingEmployee {
      get { return _editing_employee; }
      set { 
        _editing_employee = value;
        if(_editing_employee.GetType() == typeof(HourlyEmployee)){
           this.PopulateEditFields((HourlyEmployee)_editing_employee); // ugly baby!
         }else {
           this.PopulateEditFields((SalariedEmployee)_editing_employee); // ugly baby!
         }
      }
    }
    
    public int EditingEmployeeIndex {
      get { return _editing_employee_index; }
      set { _editing_employee_index = value; }
    }
    
    public String FirstName {
      get { return _firstNameTextBox.Text; }
      set { _firstNameTextBox.Text = value; }
    }
    
    public String MiddleName {
      get { return _middleNameTextBox.Text; }
      set { _middleNameTextBox.Text = value; }
    }
    
    public String LastName {
      get { return _lastNameTextBox.Text; }
      set { _lastNameTextBox.Text = value; }
    }
    
    public DateTime Birthday {
      get { return _birthdayPicker.Value; }
      set { _birthdayPicker.Value = value; }
    }
   
    public String MainTextBoxText {
      set { _mainTextBox.Text = value; }
    }
   
    public Sex Gender {
      get { return this.RadioButtonToSexEnum(); }
      set { this.SetRadioButton(value); }
    }
    
    public bool CreateMode {
      get { return _createMode; }
      set { _createMode = value; }
    }
    
    public String Salary {
      get { return _salaryTextBox.Text; }
      set { _salaryTextBox.Text = value; }
    }
    
    public String HoursWorked {
      get { return _hoursWorkedTextBox.Text; }
      set { _hoursWorkedTextBox.Text = value; }
    }
    
    public String HourlyRate {
      get { return _hourlyRateTextBox.Text; }
      set { _hourlyRateTextBox.Text = value; }
    }
    
    public String EmployeeNumber {
      get { return _employeeNumberTextBox.Text; }
      set { _employeeNumberTextBox.Text = value; }
    }
    
    public bool SubmitOK {
      set { _submitButton.Enabled = value; }
    }
    
    public View(IController externalHandler){
      this.InitializeComponent(externalHandler);
    }
    
    private void InitializeComponent(IController controller){
      this.InitializeMenus(controller);
     _mainTablePanel = new TableLayoutPanel();
     _mainTablePanel.RowCount = 2;
     _mainTablePanel.ColumnCount = 2;
     _mainTablePanel.Anchor = AnchorStyles.Top |   AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;
     _mainTablePanel.Padding = new Padding(10, 50, 10, 10);
    // _mainTablePanel.Dock = DockStyle.Left;
     _mainTablePanel.Height = 475;
     _mainTablePanel.Width = 700;
     _infoTablePanel = new TableLayoutPanel();
     _infoTablePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;
     _infoTablePanel.RowCount = 9; // was 2
     _infoTablePanel.ColumnCount = 2;
     _infoTablePanel.Height = 300;
     _infoTablePanel.Width = 425;
     _buttonPanel = new FlowLayoutPanel();
     _buttonPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;
     _buttonPanel.Width = 500;
     _buttonPanel.Height = 200;
     
     _mainTextBox = new TextBox();
     _mainTextBox.Height = 200;
     _mainTextBox.Width = 400;
     _mainTextBox.Multiline = true;
     _mainTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;
     
     _firstNameLabel = new Label();
     _firstNameLabel.Text = "First Name:";
     _middleNameLabel = new Label();
     _middleNameLabel.Text = "Middle Name:";
     _lastNameLabel = new Label();
     _lastNameLabel.Text = "Last Name:";
     _hoursWorkedLabel = new Label();
     _hoursWorkedLabel.Text = "Hours Worked:";
     _hourlyRateLabel = new Label();
     _hourlyRateLabel.Text = "Hourly Rate:";
     _salaryLabel = new Label();
     _salaryLabel.Text = "Salary:";
     _employeeNumberLabel = new Label();
     _employeeNumberLabel.Text = "Employee Number:";
     _employeeNumberLabel.Width = 125;
     
     
     _birthdayLabel = new Label();
     _birthdayLabel.Text = "Birthday";
     _genderLabel = new Label();
     _genderLabel.Text = "Gender";
     _firstNameTextBox = new TextBox();
     _firstNameTextBox.Width = 200;
     _middleNameTextBox = new TextBox();
     _middleNameTextBox.Width = 200;
     _lastNameTextBox = new TextBox();
     _lastNameTextBox.Width = 200;
     _hoursWorkedTextBox = new TextBox();
     _hoursWorkedTextBox.Width = 200;
     _hourlyRateTextBox = new TextBox();
     _hourlyRateTextBox.Width = 200;
     _salaryTextBox = new TextBox();
     _salaryTextBox.Width = 200;
     _employeeNumberTextBox = new TextBox();
     _employeeNumberTextBox.Width = 200;
     
     _birthdayPicker = new DateTimePicker();
     _genderBox = new GroupBox();
     _genderBox.Text = "Gender";
     _genderBox.Height = 75;
     _genderBox.Width = 200;
     _maleRadioButton = new RadioButton();
     _maleRadioButton.Text = "Male";
     _maleRadioButton.Checked = true;
     _maleRadioButton.Location = new Point(10, 20);
     _femaleRadioButton = new RadioButton();
     _femaleRadioButton.Text = "Female";
     _femaleRadioButton.Location = new Point(10, 40);
     _genderBox.Controls.Add(_maleRadioButton);
     _genderBox.Controls.Add(_femaleRadioButton);
     _clearButton = new Button();
     _clearButton.Text = "Clear";
     _clearButton.Name = "Clear";
     _clearButton.Click += controller.UniversalHandler;
     
     _submitButton = new Button();
     _submitButton.Text = "Submit";
     _submitButton.Name = "Submit";
     _submitButton.Click += controller.UniversalHandler;
     _submitButton.Enabled = false;
     
     _infoTablePanel.SuspendLayout();
     _infoTablePanel.Controls.Add(_firstNameLabel);
     _infoTablePanel.Controls.Add(_firstNameTextBox);
     _infoTablePanel.Controls.Add(_middleNameLabel);
     _infoTablePanel.Controls.Add(_middleNameTextBox);
     _infoTablePanel.Controls.Add(_lastNameLabel);
     _infoTablePanel.Controls.Add(_lastNameTextBox);
     _infoTablePanel.Controls.Add(_birthdayLabel);
     _infoTablePanel.Controls.Add(_birthdayPicker);
     _infoTablePanel.Controls.Add(_genderLabel);
     _infoTablePanel.Controls.Add(_genderBox);
     _infoTablePanel.Controls.Add(_employeeNumberLabel);
     _infoTablePanel.Controls.Add(_employeeNumberTextBox);
     _infoTablePanel.Controls.Add(_hoursWorkedLabel);
     _infoTablePanel.Controls.Add(_hoursWorkedTextBox);
     _infoTablePanel.Controls.Add(_hourlyRateLabel);
     _infoTablePanel.Controls.Add(_hourlyRateTextBox);
     _infoTablePanel.Controls.Add(_salaryLabel);
     _infoTablePanel.Controls.Add(_salaryTextBox);
     _infoTablePanel.Dock = DockStyle.Top;
     
     _buttonPanel.SuspendLayout();
     _buttonPanel.Controls.Add(_clearButton);
     _buttonPanel.Controls.Add(_submitButton);
     
     _mainTablePanel.SuspendLayout();
     _mainTablePanel.Controls.Add(_mainTextBox);
     _mainTablePanel.Controls.Add(_infoTablePanel);
     _mainTablePanel.Controls.Add(_buttonPanel);
     _mainTablePanel.SetColumnSpan(_buttonPanel, 2);
     
      this.SuspendLayout();
      this.Controls.Add(_mainTablePanel); 
      this.Width = WINDOW_WIDTH;
      this.Height = WINDOW_HEIGHT;
      this.MinimumSize = new Size(WINDOW_WIDTH, WINDOW_HEIGHT);
      //this.MaximumSize = new Size(WINDOW_WIDTH, WINDOW_HEIGHT);
      this.Text = WINDOW_TITLE;
      _infoTablePanel.ResumeLayout();
      _buttonPanel.ResumeLayout();
      _mainTablePanel.ResumeLayout();
      this.ResumeLayout();
      _openFileDialog = new OpenFileDialog();
      _saveFileDialog = new SaveFileDialog();
      this.EnableHourlyFields(false);
      this.EnableSalaryFields(false);
      this.SetWindowTitleBasedOnMode();
      
    }
    
    private void InitializeMenus(IController controller){
      // setup the menus
      _ms = new MenuStrip();
      
      _fileMenu = new ToolStripMenuItem("File");
      _loadMenuItem = new ToolStripMenuItem("Load...", null, new EventHandler(controller.UniversalHandler));
      _loadMenuItem.Name = "Load";
      _saveMenuItem = new ToolStripMenuItem("Save...", null, new EventHandler(controller.UniversalHandler));
      _saveMenuItem.Name = "Save";
      _exitMenuItem = new ToolStripMenuItem("Exit", null, new EventHandler(controller.UniversalHandler));
      _exitMenuItem.Name = "Exit";
      
      _editMenu = new ToolStripMenuItem("Edit");
      _listMenuItem = new ToolStripMenuItem("List", null, new EventHandler(controller.UniversalHandler));
      _listMenuItem.Name = "List";
      _sortMenuItem = new ToolStripMenuItem("Sort", null, new EventHandler(controller.UniversalHandler));
      _sortMenuItem.Name = "Sort";
      _newSalariedEmployeeMenuItem = new ToolStripMenuItem("New Salaried Employee", null,  
                                                          new EventHandler(controller.UniversalHandler));
      _newSalariedEmployeeMenuItem.Name = "NewSalariedEmployee";
      _newHourlyEmployeeMenuItem = new ToolStripMenuItem("New Hourly Employee", null, 
                                                          new EventHandler(controller.UniversalHandler));
      _newHourlyEmployeeMenuItem.Name = "NewHourlyEmployee";
      _editEmployeeMenuItem = new ToolStripMenuItem("Edit Employee", null, 
                                                          new EventHandler(controller.UniversalHandler));
      _editEmployeeMenuItem.Name = "EditEmployee";
      _deleteEmployeeMenuItem = new ToolStripMenuItem("Delete Employee", null, 
                                                          new EventHandler(controller.UniversalHandler));
      _deleteEmployeeMenuItem.Name = "DeleteEmployee";
     
     
      _fileMenu.DropDownItems.Add(_loadMenuItem);
      _fileMenu.DropDownItems.Add(_saveMenuItem);
      _fileMenu.DropDownItems.Add(_exitMenuItem);
      _ms.Items.Add(_fileMenu);
      
      _editMenu.DropDownItems.Add(_listMenuItem);
      _editMenu.DropDownItems.Add(_sortMenuItem);
      _editMenu.DropDownItems.Add("-");
      _editMenu.DropDownItems.Add(_newSalariedEmployeeMenuItem);
      _editMenu.DropDownItems.Add(_newHourlyEmployeeMenuItem);
      _editMenu.DropDownItems.Add(_editEmployeeMenuItem);
      _editMenu.DropDownItems.Add("-");
      _editMenu.DropDownItems.Add(_deleteEmployeeMenuItem);
      _ms.Items.Add(_editMenu);
      
      _ms.Dock = DockStyle.Top;
      this.MainMenuStrip = _ms;
      this.Controls.Add(_ms);
     
    }
    
    public void SetWindowTitleBasedOnMode(){
       switch(Mode){
         case ViewMode.RESTING: this.Text = WINDOW_TITLE + "- Resting";
                                break;
         case ViewMode.SALARIED: this.Text = WINDOW_TITLE + "- New Salaried Employee";
                                 break;
         case ViewMode.HOURLY: this.Text = WINDOW_TITLE + " - New Hourly Employee";
                                break;
         case ViewMode.EDIT: this.Text = WINDOW_TITLE + "- Edit Employee";
                                break;
       }
    }
     
    public void ClearInputFields(){
      _firstNameTextBox.Text = String.Empty;
      _middleNameTextBox.Text = String.Empty;
      _lastNameTextBox.Text = String.Empty;
      _maleRadioButton.Checked = true;
      _birthdayPicker.Value = DateTime.Now;
      _hoursWorkedTextBox.Text = String.Empty;
      _hourlyRateTextBox.Text = String.Empty;
      _salaryTextBox.Text = String.Empty;
      _employeeNumberTextBox.Text = String.Empty;
    }
    
    private Sex RadioButtonToSexEnum(){
      Sex gender = Sex.MALE;
      if(_maleRadioButton.Checked){
        gender = Sex.MALE;
      }else{
          gender = Sex.FEMALE;
        }
      return gender;
    }
    
    private void SetRadioButton(Sex gender){
      if(gender == Sex.MALE){
        _maleRadioButton.Checked = true;
      }else{
        _femaleRadioButton.Checked = true;
      }
    }
    
    public void EnableSalaryFields(bool state){
      _salaryLabel.Enabled = state;
      _salaryTextBox.Enabled = state;
    }
    
    public void EnableHourlyFields(bool state){
      _hoursWorkedLabel.Enabled = state;
      _hoursWorkedTextBox.Enabled = state;
      _hourlyRateLabel.Enabled = state;
      _hourlyRateTextBox.Enabled = state;
    }
    
    public void EnableSubmitButton(bool state){
      _submitButton.Enabled = state;
    }
    
    public void DisplayEmployeeInfo(String[] employees_info) {
      StringBuilder sb = new StringBuilder();
      foreach(String s in employees_info){
        sb.Append(s + "\r\n");
      }
      _mainTextBox.Text = sb.ToString();
    }
    
    public IEmployee GetNewSalariedEmployee(){
      SalariedEmployee employee = new SalariedEmployee();
      PayInfo p = new PayInfo();
      p.Salary = Double.Parse(Salary);
      employee.PayInfo = p;
      this.FillInStandardEmployee(employee);
      return employee;
    }
     
    public IEmployee GetNewHourlyEmployee(){
      HourlyEmployee employee = new HourlyEmployee();
      PayInfo p = new PayInfo();
      p.HoursWorked = Double.Parse(HoursWorked);
      p.HourlyRate = Double.Parse(HourlyRate);
      employee.PayInfo = p;
      this.FillInStandardEmployee(employee);
      return employee;
    }
     
    public IEmployee GetEditedEmployee(){
      if(EditingEmployee.GetType() == typeof(HourlyEmployee)){
        return this.FillInEditedEmployee((HourlyEmployee)EditingEmployee);
      }else{
        return this.FillInEditedEmployee((SalariedEmployee)EditingEmployee);
        }
    }
    
    public String GetSaveFile(){
       _saveFileDialog.ShowDialog();
       return _saveFileDialog.FileName;
    }
    
    public String GetLoadFile(){
      _openFileDialog.ShowDialog();
      return _openFileDialog.FileName;
    }
    
    public int SelectedLineNumber(){
      int index = _mainTextBox.SelectionStart;
      int line_number = _mainTextBox.GetLineFromCharIndex(index);
      return line_number;
    }
    
    private IEmployee FillInEditedEmployee(SalariedEmployee employee){
      employee.PayInfo.Salary = Double.Parse(Salary);
      return this.FillInStandardEmployee(employee);
    }
    
    private IEmployee FillInEditedEmployee(HourlyEmployee employee){
      employee.PayInfo.HoursWorked = Double.Parse(HoursWorked);
      employee.PayInfo.HourlyRate = Double.Parse(HourlyRate);
      return this.FillInStandardEmployee(employee);
    }
    
    private IEmployee FillInStandardEmployee(IEmployee employee){
      employee.FirstName = FirstName;
      employee.MiddleName = MiddleName;
      employee.LastName = LastName;
      employee.Gender = Gender;
      employee.Birthday = Birthday;
      employee.EmployeeNumber = EmployeeNumber; 
      return employee;
    }
    
    public void PopulateEditFields(SalariedEmployee employee){
      EnableSalaryFields(true);
      EnableHourlyFields(false);
      Salary = employee.PayInfo.Salary.ToString();
      this.PopulateStandardEditFields(employee);
      
    }
    
    public void PopulateEditFields(HourlyEmployee employee){
      EnableHourlyFields(true);
      EnableSalaryFields(false);
      HoursWorked = employee.PayInfo.HoursWorked.ToString();
      HourlyRate = employee.PayInfo.HourlyRate.ToString();
      this.PopulateStandardEditFields(employee);
    }
    
    private void PopulateStandardEditFields(IEmployee employee){
      FirstName = employee.FirstName;
      MiddleName = employee.MiddleName;
      LastName = employee.LastName;
      Birthday = employee.Birthday;
      Gender = employee.Gender;
      EmployeeNumber = employee.EmployeeNumber;
    }

  } // end View class definition
} // end namespace