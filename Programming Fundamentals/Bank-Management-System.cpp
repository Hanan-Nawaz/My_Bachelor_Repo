//Bank Management System by Abdul Hanan Nawaz
//hanannawaz0@gmail.com

#include<iostream>
#include<fstream>
#include<string>
#include<cstdio>

using namespace std;

int func_createacc();
int func_depositmon();
int func_withdrawmon();
void func_balcheck();
void func_delete();
int func_modify_acc();
void func_all();

int acnocheck,money;

struct banksystem
{
	int acno;
	char name[50];
	char type;
	int depm;
	
}	bank;

int func_createacc()
{
   	
	system("CLS");
	
	cout<<"\n\n"<<endl;
	
	cout<<"\t\t\tEnter your New Account Number: ";
	cin>>bank.acno;
	cout<<"\n\n";
	cout<<"\t\t\tEnter Account holder Name: ";
	cin>>bank.name;
	cout<<"\n\n";
	cout<<"\t\t\tSelect Account Type\n\n";
	cout<<"\t\t\t[c for current]and[s for saving]Account: ";
	cin>>bank.type;
	bank.type=toupper(bank.type);
	cout<<"\n\n";
	cout<<"\t\t\tEnter Amount you want to deposit: ";
	cin>>bank.depm;
	
	ofstream outfile;
	outfile.open("save.txt" , ios::binary|ios::app);
	outfile.write((char *)&bank,sizeof(bank));
	outfile.close();
	 	
	cout<<"\n\t\t\tAccount Created successfylly..."<<endl;
	cout<<"\n\n"<<endl;
	cout<<"\t\t\t";
	system("pause");
	return 0;
	
}

int func_depositmon()
{
	
	system("CLS");
	
	cout<<"\n\n"<<endl;
	cout<<"\t\t\tEnter your Account Number: ";
	cin>>acnocheck;
	
	fstream file;
	file.open("save.txt",ios::binary|ios::out|ios::in);
	file.seekg(0);
	while(file.read((char *)&bank,sizeof(bank)))
	{
		if(bank.acno==acnocheck)
		{
			cout<<"\n\n"<<endl;
			cout<<"\t\t\tEnter the Amount you want to deposit\n";
		 	cin>>money;
				
		 	bank.depm=bank.depm+money;
		 	cout<<"\n\n"<<endl;
		 	cout<<"\t\t\tYour Current balance is:"<<bank.depm<<endl;
			file.seekp(-sizeof(bank),ios::end);
			file.write((char *)&bank,sizeof(bank));
		 	
		 
		 	
		 	cout<<"\n\n"<<endl;
		 	cout<<"\n\t\t\tDeposited successfylly...";
		 	cout<<"\n\n"<<endl;
		 	cout<<"\t\t\t";
			system("pause");
			
		 	
		}
		else
		{
			cout<<"\n\n\n";
			cout<<"\n\n\t\t\t";
			system("pause");
		}
		 	
	}

	file.close();
	return 0;	
}
int func_withdrawmon()
{
	system("CLS");

	cout<<"\n\n";
	cout<<"\t\t\tEnter your Account Number: ";
	cin>>acnocheck;
	
	fstream file;
	file.open("save.txt",ios::binary|ios::in);
	file.seekg(0);
	while(file.read((char *)&bank,sizeof(bank)))
	{
		if(bank.acno==acnocheck)
		{
			cout<<"\n\n";
			cout<<"\t\t\tEnter the Amount you want to Withdraw\n";
			cin>>money;
			
			if(bank.depm>=money)
	 		{
				
				 	
			 	bank.depm=bank.depm-money;
			 	
			 	cout<<"\n\n"<<endl;
		 		cout<<"\t\t\tYour Current balance is:"<<bank.depm<<endl;
		 	
			 	file.seekp(-sizeof(bank),ios::cur);
			 	file.write((char *)&bank,sizeof(bank));
			 	
			 	cout<<"\n\t\t\tWithdrawed successfylly...";
			 	cout<<"\n\n\t\t\t";
				system("pause");
				
			}
			else
			{
				cout<<"\n\n";
				cout<<"\t\t\tInsufficient Balance...."<<endl;
				cout<<"\t\t\t";
				system("pause");
				
			}
			
			
		}
		else
		{
			cout<<"\n\n\n";
			cout<<"\n\n\t\t\t";
			system("pause");
		}
	
	}
	
	
	
	file.close();

	return 0;
}

void func_balcheck()
{
	system("CLS");
	
	cout<<"\n\n";
	cout<<"\t\t\tEnter your Account Number: ";
	cin>>acnocheck;
	
	ifstream infile;
	infile.open("save.txt",ios::binary|ios::in);
	while(infile.read((char *)&bank,sizeof(bank)))
	{
	
	
		if(bank.acno==acnocheck)
		{
			cout<<"\n\n\n";
			cout<<"\t\t\tAccount Number\tHolder Name\tType\tBalance"<<endl;
			cout<<"\t\t\t=================================================="<<endl;
			cout<<"\t\t\t"<<bank.acno<<"\t\t"<<bank.name<<"\t\t"<<bank.type<<"\t\t"<<bank.depm<<endl;
			
		 	cout<<"\n\t\t\tRecord Checked successfylly...";
		 	cout<<"\n\n\t\t\t";
			system("pause");
			
		}
		else
		{
			cout<<"\n\n\n";
			cout<<"\n\n\t\t\t";
			system("pause");
		}
	}

	
	
	infile.close();
}

void func_delete()
{
	
	system("CLS");
	
	
	ofstream outfile;
	outfile.open("temp.txt",ios::binary|ios::out);
	ifstream infile;
	infile.open("save.txt",ios::binary|ios::in);
	
	cout<<"\n\n";
	cout<<"\t\t\tEnter your Account Number: ";
	cin>>acnocheck;
	
	while(infile.read((char *)&bank, sizeof(bank)))
	{
		if(bank.acno!=acnocheck)
		{
			outfile.write((char *)&bank,sizeof(bank));
			infile.close();
			outfile.close();
			remove("save.txt");
			rename("temp.txt","save.txt");
			
			cout<<"\n\n";
			cout<<"\t\t\tAccount Close Successfully...."<<endl;
		}
	}

	cout<<"\n\n\t\t\t";
	system("pause");	
}

int func_modify_acc()
{
	system("CLS");
		
	cout<<"\n\n";
	cout<<"\t\t\tEnter your Account Number: ";
	cin>>acnocheck;
	
	fstream infile;
	infile.open("save.txt",ios::binary|ios::in|ios::out);
	infile.seekg(0);
	while(infile.read((char *)&bank,sizeof(bank)))
	{
		if(bank.acno==acnocheck)
		{
			
			cout<<"\n\n"<<endl;
			cout<<"\t\t\tEnter your New Account Number: ";
			cin>>bank.acno;
			cout<<"\n";
			cout<<"\t\t\tEnter Account holder Name: ";
			cin>>bank.name;
			cout<<"\n";
			cout<<"\t\t\tSelect Account Type\n\n";
			cout<<"\t\t\t[c for current]and[s for saving]Account: ";
			cin>>bank.type;
			bank.type=toupper(bank.type);
			cout<<"\n";
			cout<<"\t\t\tEnter Amount you want to deposit: ";
			cin>>bank.depm;
			
			infile.seekp(-sizeof(bank),ios::cur);
			infile.write((char *)&bank,sizeof(bank));
			
			 	
			cout<<"\n\t\t\tAccount Modified successfylly...";
			cout<<"\n\n\t\t\t";
			system("pause");
			
		}
		else
		{
			cout<<"\n\n\n";
			cout<<"\n\n\t\t\t";
			system("pause");
		}
		
	}
	
	
	
	infile.close();
		return 0;	
}
void func_all()
{
	int count=1;
	system("CLS");
	ifstream infile;
	infile.open("save.txt",ios::binary|ios::in);
	
	
	cout<<"\n\t\t\tNumber\tAccount Number\tHolder Name\tAccount Type\tBalance"<<endl;
	cout<<"\t\t\t==============================================================="<<endl;
	while(infile.read((char *)&bank, sizeof(bank)))
	{	
		cout<<"\n\n";
		cout<<"\t\t\t"<<count<<"\t"<<bank.acno<<"\t\t"<<bank.name<<"\t\t"<<bank.type<<"\t\t"<<bank.depm<<endl;
		count++;
	}
	
	cout<<"\n\n";
	cout<<"\t\t\tList displayed successfully......"<<endl;
	cout<<"\n\n\t\t\t";
	system("pause");
	
	infile.close();
	
}
int main()
{
	int select;

  do
	{
		system("CLS");
		cout<<"\t\t\t****************************"<<endl;
		cout<<"\t\t\t*==========================*"<<endl;
		cout<<"\t\t\t*| BANK MANAGEMENT SYSTEM |*"<<endl; // main menu showing
		cout<<"\t\t\t*==========================*"<<endl;
		cout<<"\t\t\t****************************\n"<<endl;

		
		cout<<"\t\t\t     ::Main Menu::\n "<<endl;
		
		cout<<"\t\t\t----------------------"<<endl;
		cout<<"\t\t\t|1| Open new Account |"<<endl;
		cout<<"\t\t\t|-|------------------|"<<endl;
		cout<<"\t\t\t|2| Deposit Amount   |"<<endl;
		cout<<"\t\t\t|-|------------------|"<<endl;
		cout<<"\t\t\t|3| Withdraw Amount  |"<<endl;
		cout<<"\t\t\t|-|------------------|"<<endl;
		cout<<"\t\t\t|4| Balance INQUIRY  |"<<endl;
		cout<<"\t\t\t|-|------------------|"<<endl;
		cout<<"\t\t\t|5| Close an Account |"<<endl;
		cout<<"\t\t\t|-|------------------|"<<endl;
		cout<<"\t\t\t|6| Modify an Account|"<<endl;
		cout<<"\t\t\t|-|------------------|"<<endl;
		cout<<"\t\t\t|7| All Accounts List|"<<endl;
		cout<<"\t\t\t|-|------------------|"<<endl;
		cout<<"\t\t\t|8|       Exit       |"<<endl;
		cout<<"\t\t\t----------------------"<<endl;
		cout<<"\t\t\t\t by Hanan Nawaz \n"<<endl;
		cout<<"\t\t\tSelect Your Option (1-8): ";
		cin>>select;
		
		switch(select)  
		{
			case 1:
				{
					func_createacc();
				
					break;	
				}
			case(2):
				{
					func_depositmon();
					break;
				}
			case(3):
				{
					func_withdrawmon();
					break;
				}
			case(4):
				{
					func_balcheck();
					break;
				}
			case(5):
				{
					func_delete();
					break;
				}
			case(6):
				{
					func_modify_acc();
					break;
				}	
			case(7):
				{
					func_all();
					break;
				}
			case(8):
				{
					//exit
					break;
				}
				
			
			default:
				{
					system("CLS");
					cout<<"\n\n\n";
					cout<<"\t\t\tYou Enter Wrong Entry!!!"<<endl;
					cout<<"\n\n\t\t\t";
					system("pause");
					break;
				}
		}
	}
while(select!=8);	

	return 0;
	
}
