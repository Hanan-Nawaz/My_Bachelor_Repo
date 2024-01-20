#include<iostream>
#include<fstream>
#include<string>  
#include<cstdio>
#include <cstdlib>

using namespace std;
fstream hotel_;

struct hotel {
	int roomnumber;
	string name;
	string age;
	string cnic;
	string mobile_no;
	string occupation; //for staff
	int pay; //for staff
	int stay;
	int price;
	struct hotel *next;

};

class hotel_system {
	
	int room_number;
	string customer_name;
	string customer_age;
	string customer_cnic;
	string customer_mobile_no;
	int customer_stay;
	string soccupation; //for staff
	int spay; //for staff
	int room_price;
	hotel * head = NULL;
	hotel * start = NULL;

	
	public:
		
void booking_portal(int room_num, string c_name, string c_age, string c_cnic,string c_mobile_no, int c_stay, int room_pri){
	
	
		
		cout<<"\n\n\t\t Price is : "<<room_price<<endl;
		
		
		hotel * newnode = new hotel();
		
		newnode->roomnumber = room_num;
		newnode->name = c_name;
		newnode->age = c_age;
		newnode->cnic = c_cnic;
		newnode->mobile_no = c_mobile_no;
		newnode->stay = c_stay;
		newnode->price = room_pri;
		newnode->next = head;
		head = newnode;
		
		hotel_.open ("rooms.txt",ios::out | ios::app);
 		hotel_<<newnode->roomnumber<<"\t\t"<<newnode->name<<"\t\t"<<newnode->age<<"\t\t"<<newnode->cnic<<"\t\t"<<newnode->mobile_no<<"\t\t"<<newnode->stay<<"\t\t"<<newnode->price<<endl;
		hotel_.close(); 
		
		cout<<"\n\n\t\t Booked Successfully! "<<endl;
		
exit;
}

void bubbleSort()
{
		hotel *ptr,*ptr1;
		ptr1=NULL;
		int swap;
		if(head==NULL)
		cout<<"list is empty"<<endl;
		else
		{
		do {
		ptr=head;
		swap=0;
		while(ptr->next!=NULL)
		{
		if(ptr->roomnumber>ptr->next->roomnumber)
		{
		int temp;
		string cust_name;
		string cust_age;
		string cust_cnic;
		string cust_mobile_no;
		int cust_stay;
		int r_price;
		
		temp=ptr->roomnumber;
		ptr->roomnumber=ptr->next->roomnumber;
		ptr->next->roomnumber=temp;
		
		cust_name=ptr->name;
		ptr->name=ptr->next->name;
		ptr->next->name=cust_name;

		cust_age=ptr->age;
		ptr->age=ptr->next->age;
		ptr->next->age=cust_age;

		cust_cnic=ptr->cnic;
		ptr->cnic=ptr->next->cnic;
		ptr->next->cnic=cust_cnic;
		
		cust_mobile_no=ptr->mobile_no;
		ptr->mobile_no=ptr->next->mobile_no;
		ptr->next->mobile_no=cust_mobile_no;

		cust_stay=ptr->stay;
		ptr->stay=ptr->next->stay;
		ptr->next->stay=cust_stay;
		
		r_price=ptr->price;
		ptr->price=ptr->next->price;
		ptr->next->price=r_price;
	
		swap=1;
		}
		ptr=ptr->next;
		}
		ptr1=ptr;
		}while(swap);
		}

}


void display(){
	
		hotel * ptr;
		ptr = head;
		system("CLS");

		cout<<"\n\n\t\t\t\t\t\t\t ======================"<<endl;
		cout<<"\t\t\t\t\t\t\t |       Bookings     |"<<endl;
		cout<<"\t\t\t\t\t\t\t ======================"<<endl;
	
		bubbleSort();
		
		cout<<"\n\n"<<endl;
		while(ptr!=NULL){
		cout<<"\t\tRoom Number : "<<ptr->roomnumber<<" | Name : "<<ptr->name<<" | Age : "<<ptr->age<<" | Cnic : "<<ptr->cnic<<" | Mobile No. : "<<ptr->mobile_no<<" | Stay : "<<ptr->stay<<" | Price : "<<ptr->price<<endl;
		ptr = ptr->next;

		}
		cout<<"\n\n\t\t"; system("pause");

}

void search(string number){
	 hotel* ptr = head;
	 int i =0;
	 if(ptr==NULL){
	 	cout<<"\n\n\t\t\t Empty List!"<<endl;
	 }
	 while(ptr!=NULL){
	 	if(ptr->mobile_no == number){
	 		cout<<"\t\tRoom Number : "<<ptr->roomnumber<<" | Name : "<<ptr->name<<" | Age : "<<ptr->age<<" | Cnic : "<<ptr->cnic<<" | Mobile No. : "<<ptr->mobile_no<<" | Stay : "<<ptr->stay<<" | Price : "<<ptr->price<<endl;
		 }
		else{
			cout<<"\t\tData not Found!"<<endl;
			i=i+1;
		}
		ptr=ptr->next;
	 }
	 system("pause");
}
	
void del(string number){
	
    hotel* temp = head;
    hotel* prev = NULL;
     
    if (temp != NULL && temp->mobile_no == number)
    {
        head = temp->next; 
        delete temp;            
        return;
    }
 
      else
    {
    while (temp != NULL && temp->mobile_no != number)
    {
        prev = temp;
        temp = temp->next;
        
    }
 
    if (temp == NULL){
    	cout<<"\t\tData not Found!"<<endl;
	}
 	cout<<"\t\t Deleted Successfully!"<<endl;

    prev->next = temp->next;
 	
    delete temp;
    }
	
	cout<<"\n\t\t";system("pause");
}

void add_staff_portal(string c_name, string c_age, string c_cnic,string c_mobile_no, string s_occupation, int s_pay){
		
		hotel * newnode = new hotel();
		
		newnode->name = c_name;
		newnode->age = c_age;
		newnode->cnic = c_cnic;
		newnode->mobile_no = c_mobile_no;
		newnode->occupation = s_occupation;
		newnode->pay = s_pay;
		newnode->next = start;
		start = newnode;
		
		hotel_.open ("staff.txt",ios::out | ios::app);
 		hotel_<<newnode->name<<"\t\t"<<newnode->age<<"\t\t"<<newnode->cnic<<"\t\t"<<newnode->mobile_no<<"\t\t"<<newnode->occupation<<"\t\t"<<newnode->pay<<endl;
		hotel_.close(); 
		
		cout<<"\n\n\t\t Added Successfully! "<<endl;
		
		
exit;
}

void staff_sort(){

		hotel *ptr,*ptr1;
		ptr1=NULL;
		int swap;
		if(start==NULL)
		cout<<"list is empty"<<endl;
		else
		{
		do {
		ptr=start;
		swap=0;
		while(ptr->next!=NULL)
		{
		if(ptr->pay<ptr->next->pay)
		{

		string cust_name;
		string cust_age;
		string cust_cnic;
		string cust_mobile_no;
		string cust_stay;
		int r_price;
		
		cust_name=ptr->name;
		ptr->name=ptr->next->name;
		ptr->next->name=cust_name;

		cust_age=ptr->age;
		ptr->age=ptr->next->age;
		ptr->next->age=cust_age;

		cust_cnic=ptr->cnic;
		ptr->cnic=ptr->next->cnic;
		ptr->next->cnic=cust_cnic;
		
		cust_mobile_no=ptr->mobile_no;
		ptr->mobile_no=ptr->next->mobile_no;
		ptr->next->mobile_no=cust_mobile_no;

		cust_stay=ptr->occupation;
		ptr->occupation=ptr->next->occupation;
		ptr->next->occupation=cust_stay;
		
		r_price=ptr->pay;
		ptr->pay=ptr->next->pay;
		ptr->next->pay=r_price;
	
		swap=1;
		}
		ptr=ptr->next;
		}
		ptr1=ptr;
		}while(swap);
		}

}

void staff_display(){
		hotel * ptr;
		ptr = start;
		system("CLS");

		cout<<"\n\n\t\t\t\t\t\t\t ======================"<<endl;
		cout<<"\t\t\t\t\t\t\t |     Staff List    |"<<endl;
		cout<<"\t\t\t\t\t\t\t ======================"<<endl;
	
		staff_sort();

		cout<<"\n\n"<<endl;
		while(ptr!=NULL){
		cout<<" Name : "<<ptr->name<<" | Age : "<<ptr->age<<" | Cnic : "<<ptr->cnic<<" | Mobile No. : "<<ptr->mobile_no<<" | Occupation : "<<ptr->occupation<<" | Pay : "<<ptr->pay<<endl;
		ptr = ptr->next;

		}
		cout<<"\n\n\t\t"; system("pause");
}

void search_staff(string number){
	 hotel* ptr = start;
	 int i =0;
	 if(ptr==NULL){
	 	cout<<"\n\n\t\t\t Empty List!"<<endl;
	 }
	 while(ptr!=NULL){
	 	if(ptr->mobile_no == number){
	 		cout<<"\t\t Name : "<<ptr->name<<" | Age : "<<ptr->age<<" | Cnic : "<<ptr->cnic<<" | Mobile No. : "<<ptr->mobile_no<<" | Occupation : "<<ptr->occupation<<" | Pay : "<<ptr->pay<<endl;
		 }
		else{
			cout<<"\t\tData not Found!"<<endl;
			i=i+1;
		}
		ptr=ptr->next;
	 }
	 system("pause");
}

void staff_menu(){
		
		int select;
		
			hotel_.open("staff.txt",ios::in);
					int c = 0;
					while(!(hotel_.eof())){
						hotel_>>customer_name>>customer_age>>customer_cnic>>customer_mobile_no>>soccupation>>spay;
						hotel * existnode = new hotel();
						
						existnode->name = customer_name;
						existnode->age = customer_age;
						existnode->cnic = customer_cnic;
						existnode->mobile_no = customer_mobile_no;
						existnode->occupation = soccupation;
						existnode->pay = spay;
						existnode->next = start;
						start = existnode;
								c++;
					}
						hotel_.close();
		
		do{
			system("CLS");
		cout<<"\n\n";
		cout<<"\t\t\t*****************************"<<endl;
		cout<<"\t\t\t*===========================*"<<endl;
		cout<<"\t\t\t*| HOTEL BLUE HEIGHT Staff |*"<<endl; // satff main menu showing
		cout<<"\t\t\t*===========================*"<<endl;
		cout<<"\t\t\t*****************************\n"<<endl;
		
		cout<<"\t\t\t    ::Staff Main Menu::\n "<<endl;
		
		cout<<"\t\t\t  -----------------------"<<endl;
		cout<<"\t\t\t  | 1|    Staff List    |"<<endl;
		cout<<"\t\t\t  |--|------------------|"<<endl;
		cout<<"\t\t\t  | 2| Add Staff Member |"<<endl;
		cout<<"\t\t\t  |--|------------------|"<<endl;
		cout<<"\t\t\t  | 3|   Search staff   |"<<endl;
		cout<<"\t\t\t  |--|------------------|"<<endl;
		cout<<"\t\t\t  | 4|      Log Out     |"<<endl;
		cout<<"\t\t\t  -----------------------"<<endl;
		
		cout<<"\t\t\t  Select Your Option (1-4): ";
		cin>>select;	
		
		switch(select){
			case(1):{
				cout<<"\n\t\t*********WELCOME!********\t"<<endl;
				staff_display();
				break;
			}
			
			case(2):{
					system("CLS");
					cout<<"\n\t\t*********WELCOME!********\t"<<endl;

					cout<<"\n\n\t\t Please Enter Your Name : ";
					cin>>customer_name;
					cout<<"\n\n\t\t Please Enter Your Age : ";
					cin>>customer_age;
					cout<<"\n\n\t\t Please Enter Your Cnic : ";
					cin>>customer_cnic;
					cout<<"\n\n\t\t Please Enter Your Mobile Number : ";
					cin>>customer_mobile_no;
					cout<<"\n\n\t\t Please Enter your Occupation : ";
					cin>>soccupation;
					cout<<"\n\t\t Please Ente pay : ";
					cin>>spay;

					add_staff_portal(customer_name,customer_age,customer_cnic,customer_mobile_no,soccupation,spay);
					break;
			}
			case(3):{
					system("CLS");
					cout<<"\n\t\t*********WELCOME!********\t"<<endl;
					string numb;
					cout<<"\n\n\t\t\t Please Enter your Number : ";
					cin>>numb;
					search_staff(numb);
					break;
			}
			case(4):{
				
				break;
			}


			
			
		}
		
		}
		while(select!=4);	
}

void main_menu(){
	
					hotel_.open("rooms.txt",ios::in);
					int c = 0;
					while(!(hotel_.eof())){
						hotel_>>room_number>>customer_name>>customer_age>>customer_cnic>>customer_mobile_no>>customer_stay>>room_price;
						hotel * existnode = new hotel();
						
						existnode->roomnumber = room_number;
						existnode->name = customer_name;
						existnode->age = customer_age;
						existnode->cnic = customer_cnic;
						existnode->mobile_no = customer_mobile_no;
						existnode->stay = customer_stay;
						existnode->price = room_price;
						existnode->next = head;
						head = existnode;
								c++;
					}
						hotel_.close(); 

		int select;
	 do
	{
		system("CLS");
		cout<<"\n\n";
		cout<<"\t\t\t*****************************"<<endl;
		cout<<"\t\t\t*===========================*"<<endl;
		cout<<"\t\t\t*|HOTEL BLUE HEIGHTS MURREE|*"<<endl; // main menu showing
		cout<<"\t\t\t*===========================*"<<endl;
		cout<<"\t\t\t*****************************\n"<<endl;

		
		cout<<"\t\t\t       ::Main Menu::\n "<<endl;
		
		cout<<"\t\t\t  -----------------------"<<endl;
		cout<<"\t\t\t  | 1|     Booking      |"<<endl;
		cout<<"\t\t\t  |--|------------------|"<<endl;
		cout<<"\t\t\t  | 2| Display  Booking |"<<endl;
		cout<<"\t\t\t  |--|------------------|"<<endl;
		cout<<"\t\t\t  | 3|  Search Booking  |"<<endl;
		cout<<"\t\t\t  |--|------------------|"<<endl;
		cout<<"\t\t\t  | 4|  Cancel Booking  |"<<endl;
		cout<<"\t\t\t  |--|------------------|"<<endl;
		cout<<"\t\t\t  | 5|    Hotel Staff   |"<<endl;
		cout<<"\t\t\t  |--|------------------|"<<endl;
		cout<<"\t\t\t  | 6|See Hotel Details |"<<endl;
		cout<<"\t\t\t  |--|------------------|"<<endl;
		cout<<"\t\t\t  | 7|       Exit       |"<<endl;
		cout<<"\t\t\t  -----------------------"<<endl;
		cout<<"\t\t\t  Select Your Option (1-7): ";
		cin>>select;

		switch(select)  
		{
			case 1:
				{
					system("CLS");
					cout<<"\n\t\t*********WELCOME!********\t"<<endl;
					cout<<"\n\n\t\t Please Enter Your Room Number : ";
					cin>>room_number;
					cout<<"\n\n\t\t Please Enter Your Name : ";
					cin>>customer_name;
					cout<<"\n\n\t\t Please Enter Your Age : ";
					cin>>customer_age;
					cout<<"\n\n\t\t Please Enter Your Cnic : ";
					cin>>customer_cnic;
					cout<<"\n\n\t\t Please Enter Your Mobile Number : ";
					cin>>customer_mobile_no;
					cout<<"\n\n\t\t Rates are 2000PKR/DAY"<<endl;
					cout<<"\n\t\t Please Enter Days of Stay : ";
					cin>>customer_stay;
					room_price = customer_stay * 2000;

					booking_portal(room_number,customer_name,customer_age,customer_cnic,customer_mobile_no,customer_stay,room_price);
					break;	
				}
			case(2):
				{
					cout<<"\n\t\t*********WELCOME!********\t"<<endl;
					display();
					break;
				}
			case(3):
				{
					system("CLS");
					cout<<"\n\t\t*********WELCOME!********\t"<<endl;
					string numb;
					cout<<"\n\n\t\t\t Please Enter your Number : ";
					cin>>numb;
					search(numb);
					break;
				}
			case(4):
				{
					system("CLS");
					cout<<"\n\t\t*********WELCOME!********\t"<<endl;
					string num;
					cout<<"\n\n\t\t\t Please Enter your Number : ";
					cin>>num;
					del(num);
					break;
				}
			case(5):
				{
					system("CLS");

					string user_name;
					string password;
					cout<<"\n\t\t\t*********WELCOME!********\t"<<endl;
					cout<<"\n\n\t\t\t Please Enter Username : ";
					cin>>user_name;
					cout<<"\n\n\t\t\t Please Enter Password : ";
					cin>>password;
					if(user_name == "hanan@hotelblueheights.com" && password == "12345678"){
						staff_menu();	
					}
					else {
						cout<<"\n\n\t\t\t Wrong Username or Password"<<endl;
						cout<<"\n\n\t\t\t"; system("pause");
						main_menu();
					}
					break;
				}
			case(6):
				{
					system("CLS");
					
					cout<<"\n\n\n\n";
					
					cout<<"\t\t\t\t**************************************************"<<endl;
					cout<<"\t\t\t\t**==============================================**"<<endl;
					cout<<"\t\t\t\t**|         HOTEL BLUE HEIGHTS MURREE          |**"<<endl; 
					cout<<"\t\t\t\t**==============================================**"<<endl;
					cout<<"\t\t\t\t**************************************************\n"<<endl;
					
					cout<<"\n\n\n";
					cout<<"\t\t\t\t                _______________                   "<<endl;
					cout<<"\t\t\t\t                |HOTEL DETAILS|                   "<<endl;
					cout<<"\t\t\t\t--------------------------------------------------"<<endl;
					cout<<"\t\t\t\t|                                                |"<<endl;					
					cout<<"\t\t\t\t| Hotel Name : HOTEL BLUE HEIGHTS MALLROAD MUREE |"<<endl;
					cout<<"\t\t\t\t|                                                |"<<endl;					
					cout<<"\t\t\t\t--------------------------------------------------"<<endl;
					cout<<"\t\t\t\t|                                                |"<<endl;					
					cout<<"\t\t\t\t| Owner Name       :      ABDUL HANAN NAWAZ      |"<<endl;
					cout<<"\t\t\t\t|                                                |"<<endl;					
					cout<<"\t\t\t\t--------------------------------------------------"<<endl;
					cout<<"\t\t\t\t|                                                |"<<endl;					
					cout<<"\t\t\t\t| Mobile Number    :      0344-7818962           |"<<endl;
					cout<<"\t\t\t\t|                                                |"<<endl;					
					cout<<"\t\t\t\t--------------------------------------------------"<<endl;
					cout<<"\t\t\t\t|                                                |"<<endl;					
					cout<<"\t\t\t\t| Manager Name     :       ..........            |"<<endl;
					cout<<"\t\t\t\t|                                                |"<<endl;					
					cout<<"\t\t\t\t--------------------------------------------------"<<endl;
					cout<<"\t\t\t\t|                                                |"<<endl;					
					cout<<"\t\t\t\t| Mobile Name       :     0311-1111111           |"<<endl;
					cout<<"\t\t\t\t|    Complaints are also handled by Manager!     |"<<endl;					
					cout<<"\t\t\t\t--------------------------------------------------"<<endl;
					cout<<"\t\t\t\t|                                                |"<<endl;					
					cout<<"\t\t\t\t| Address           :      MALLROAD MUREE        |"<<endl;
					cout<<"\t\t\t\t|   One of the Most Rated Hotel on booking.com!  |"<<endl;					
					cout<<"\t\t\t\t--------------------------------------------------"<<endl;
					cout<<"\n\n\n\t\t\t\t"; system("pause");
					break;
				}
			case(7):
			{
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
		while(select!=7);
	}
	
};

int main(){
	hotel_system obj;
	obj.main_menu();
}
