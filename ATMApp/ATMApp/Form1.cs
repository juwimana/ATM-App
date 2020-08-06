using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLDll;

namespace ATMApp
{
    /*Name: Jean Marie Uwimana
     * Project: Working With Databases
     * Date:04/15/16
     */
    public partial class ATM : Form
    {
        // instance variables used to manipulate database
        private Connection myConnection;
        private Statement myStatement;
        private ResultSet myResultSet;
        string userAccountNumber, pin,firstName;
        double balance;
        bool withdrawSelected = false;
        bool depositSelected = false;
        bool doneSelected = false;

        public ATM()
        {
            InitializeComponent();

            // establish connection to database
            try
            {
                // connect to database
                SQL sql = new SQL();
                String databaseURL = "http://www.boehnecamp.com/phpMyAdmin/razorsql_mysql_bridge.php";
                myConnection = sql.getConnection(databaseURL);
                // create Statement for executing SQL
                myStatement = myConnection.createStatement(databaseURL);
            }
            catch (Exception)
            {
                textBox1.Text = "Cannot connect to database server";
            }
        }
        private void comboBox1_Click(object sender, EventArgs e)
        {
            loadAccountNumbers();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            userAccountNumber = comboBox1.Text;
            textBox1.Clear();
            textBox1.Text = "Please enter your Pin Number.";
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;
            btn0.Enabled = true;
            btnDone.Enabled = true;
            comboBox1.Enabled = false;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            btnEnter.Enabled = true;
            Button b = (Button)sender;
            txtBoxField.Text += b.Text;
            
        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (doneSelected == true)
            {
                if (withdrawSelected == true)
                {
                    btnEnter.Enabled = false;
                    btn1.Enabled = false;
                    btn2.Enabled = false;
                    btn3.Enabled = false;
                    btn4.Enabled = false;
                    btn5.Enabled = false;
                    btn6.Enabled = false;
                    btn7.Enabled = false;
                    btn8.Enabled = false;
                    btn9.Enabled = false;
                    btn0.Enabled = false;
                    balance -= Convert.ToDouble(txtBoxField.Text);
                    textBox1.Text = "Withdrawal amount is " + txtBoxField.Text;
                    txtBoxField.Clear();
                    btnBalance.Enabled = true;
                    btnWithdraw.Enabled = true;
                    btnDeposit.Enabled = true;
                    updateBalance();

                }
                else
                {
                    if (depositSelected == true)
                    {
                        btnEnter.Enabled = false;
                        btn1.Enabled = false;
                        btn2.Enabled = false;
                        btn3.Enabled = false;
                        btn4.Enabled = false;
                        btn5.Enabled = false;
                        btn6.Enabled = false;
                        btn7.Enabled = false;
                        btn8.Enabled = false;
                        btn9.Enabled = false;
                        btn0.Enabled = false;
                        balance += Convert.ToDouble(txtBoxField.Text);
                        textBox1.Text = "Deposit amount is " + txtBoxField.Text;
                        txtBoxField.Clear();
                        btnBalance.Enabled = true;
                        btnWithdraw.Enabled = true;
                        btnDeposit.Enabled = true;
                        updateBalance();
                    }
                    else
                    {
                        retrieveAccountInformation();
                        if (txtBoxField.Text == pin)
                        {
                            txtBoxField.Clear();
                            textBox1.Clear();
                            btnEnter.Enabled = false;
                            btn1.Enabled = false;
                            btn2.Enabled = false;
                            btn3.Enabled = false;
                            btn4.Enabled = false;
                            btn5.Enabled = false;
                            btn6.Enabled = false;
                            btn7.Enabled = false;
                            btn8.Enabled = false;
                            btn9.Enabled = false;
                            btn0.Enabled = false;
                            btnBalance.Enabled = true;
                            btnWithdraw.Enabled = true;
                            btnDeposit.Enabled = true;
                            textBox1.Text = firstName + " you have a balance of "
                                + balance.ToString("c");
                        }
                        else
                        {
                            txtBoxField.Clear();
                            textBox1.Clear();
                            textBox1.Text = "Please enter a valid PIN";
                        }
                    }
                }
            }
            else
            {
                if (withdrawSelected == true)
                {
                    btnEnter.Enabled = false;
                    btn1.Enabled = false;
                    btn2.Enabled = false;
                    btn3.Enabled = false;
                    btn4.Enabled = false;
                    btn5.Enabled = false;
                    btn6.Enabled = false;
                    btn7.Enabled = false;
                    btn8.Enabled = false;
                    btn9.Enabled = false;
                    btn0.Enabled = false;
                    balance -= Convert.ToDouble(txtBoxField.Text);
                    textBox1.Text = "Withdrawal amount is " + txtBoxField.Text;
                    txtBoxField.Clear();
                    btnBalance.Enabled = true;
                    btnWithdraw.Enabled = true;
                    btnDeposit.Enabled = true;
                    updateBalance();

                }
                else
                {
                    if (depositSelected == true)
                    {
                        btnEnter.Enabled = false;
                        btn1.Enabled = false;
                        btn2.Enabled = false;
                        btn3.Enabled = false;
                        btn4.Enabled = false;
                        btn5.Enabled = false;
                        btn6.Enabled = false;
                        btn7.Enabled = false;
                        btn8.Enabled = false;
                        btn9.Enabled = false;
                        btn0.Enabled = false;
                        balance += Convert.ToDouble(txtBoxField.Text);
                        textBox1.Text = "Deposit amount is " + txtBoxField.Text;
                        txtBoxField.Clear();
                        btnBalance.Enabled = true;
                        btnWithdraw.Enabled = true;
                        btnDeposit.Enabled = true;
                        updateBalance();
                    }
                    else
                    {
                        retrieveAccountInformation();
                        if (txtBoxField.Text == pin)
                        {
                            txtBoxField.Clear();
                            textBox1.Clear();
                            btnEnter.Enabled = false;
                            btn1.Enabled = false;
                            btn2.Enabled = false;
                            btn3.Enabled = false;
                            btn4.Enabled = false;
                            btn5.Enabled = false;
                            btn6.Enabled = false;
                            btn7.Enabled = false;
                            btn8.Enabled = false;
                            btn9.Enabled = false;
                            btn0.Enabled = false;
                            btnBalance.Enabled = true;
                            btnWithdraw.Enabled = true;
                            btnDeposit.Enabled = true;
                            textBox1.Text = firstName + " you have a balance of "
                                + balance.ToString("c");
                        }
                        else
                        {
                            txtBoxField.Clear();
                            textBox1.Clear();
                            textBox1.Text = "Please enter a valid PIN";
                        }
                    }

                }
            }
        }
        private void btnBalance_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Balance is " + balance.ToString("c");
        }
        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            withdrawSelected = true;
            btnBalance.Enabled = false;
            doneSelected = false;
            depositSelected = false;
            btnWithdraw.Enabled = false;
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;
            btn0.Enabled = true;
            textBox1.Text = "Please enter withdrawal amount.";

        }
        private void btnDeposit_Click(object sender, EventArgs e)
        {
            depositSelected = true;
            doneSelected = false;
            withdrawSelected = false;
            btnBalance.Enabled = false;
            btnDeposit.Enabled = false;
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;
            btn0.Enabled = true;
            textBox1.Text = "Please enter deposit amount.";
        }
        private void btnDone_Click(object sender, EventArgs e)
        {
            updateBalance();
            doneSelected = true;
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btn5.Enabled = false;
            btn6.Enabled = false;
            btn7.Enabled = false;
            btn8.Enabled = false;
            btn9.Enabled = false;
            btn0.Enabled = false;
            btnWithdraw.Enabled = false;
            btnEnter.Enabled = false;
            btnBalance.Enabled = false;
            btnDone.Enabled = false;
            btnDeposit.Enabled = false;
            comboBox1.Enabled = true;
            withdrawSelected = false;
            depositSelected = false;
            loadAccountNumbers();
            textBox1.Text = "Please select your account number.";

        }
        private void loadAccountNumbers()
        {
            // get all account numbers from database
            try
            {
                myResultSet = myStatement.executeQuery("SELECT accountNumber FROM accountInformation");

                // add account numbers to comboBox1
                while (myResultSet.next())
                {
                    comboBox1.Items.Add(myResultSet.getString("accountNumber"));
                }

                myResultSet.close(); // close myResultSet

            } // end try

            catch (Exception)
            {
                textBox1.Text = "Error in loadig account numbers";
            }

        } // end method loadAccountNumbers

        private void retrieveAccountInformation()
        {
            //get account information
            try
            {
                myResultSet = myStatement.executeQuery("SELECT pin, " +
                "firstName, balanceAmount FROM accountInformation " +
                "WHERE accountNumber = " + userAccountNumber + "");

                //get next result
                if (myResultSet.next())
                {
                     pin = myResultSet.getString("pin");
                     firstName = myResultSet.getString("firstName");
                     balance = myResultSet.getDouble("balanceAmount");
                }

                myResultSet.close(); // close myResultSet

            } // end try

            catch (Exception)
            {
                textBox1.Text = "Error in retrieving account information";
            }

        } // end method retrieveAccountInformation

        //update database after withdrawing
        private void updateBalance()
        {
            //update balance in database
            try
            {
                myStatement.executeUpdate("UPDATE accountInformation" +
                " SET balanceAmount = " + balance + " WHERE " +
                "accountNumber = '" + userAccountNumber + "'");
            }
            catch (Exception)
            {
                textBox1.Text = "Error in updateBalance";
            }

        } // end method updateBalance

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Please select your account number";
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // close statement and database connection
            myStatement.close();
            myConnection.close();
        }
    }
}
