package com.example.agecalculator;

import androidx.appcompat.app.AppCompatActivity;

import android.app.DatePickerDialog;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.View;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.TextView;
import android.widget.Toast;

import org.joda.time.Period;
import org.joda.time.PeriodType;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.Locale;

public class HomeActivity extends AppCompatActivity {

    int current_date ;
    int current_month ;
    int current_year ;
    int date ;
    int month ;
    int year ;
    int years;
    int months;
    int days;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home);

        getSupportActionBar().hide();

        ImageButton button = findViewById(R.id.website_link);
        EditText age_text = findViewById(R.id.age);
        TextView textView = findViewById(R.id.btn_calculate);
        TextView date_tv  = findViewById(R.id.day);
        TextView month_tv  = findViewById(R.id.month);
        TextView year_tv  = findViewById(R.id.year);
        TextView inmonths_tv  = findViewById(R.id.in_months);
        TextView yinweeks_tv  = findViewById(R.id.in_weeks);
        TextView indays_tv  = findViewById(R.id.in_days);

        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Uri url = Uri.parse("https://hanannawaz.com/");
                Intent intent = new Intent(Intent.ACTION_VIEW, url);
                startActivity(intent);
            }
        });

        age_text.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Calendar calender = Calendar.getInstance();
                date = calender.get(Calendar.DAY_OF_MONTH);
                month = calender.get(Calendar.MONTH);
                year = calender.get(Calendar.YEAR);

                DatePickerDialog datePickerDialog = new DatePickerDialog(HomeActivity.this, new DatePickerDialog.OnDateSetListener() {
                    @Override
                    public void onDateSet(DatePicker datePicker, int selected_year, int selected_month, int selected_day) {
                        Calendar myCalendar = Calendar.getInstance();
                        myCalendar.set(Calendar.YEAR, selected_year);
                        myCalendar.set(Calendar.MONTH, selected_month);
                        myCalendar.set(Calendar.DAY_OF_MONTH, selected_day);
                        String myFormat = "dd/MM/yyyy";
                        SimpleDateFormat sdf = new SimpleDateFormat(myFormat, Locale.FRANCE);

                        age_text.setText(sdf.format(myCalendar.getTime()));

                        date = selected_day;
                        month = selected_month;
                        year = selected_year;
                    }
                }, date, month, year);

                datePickerDialog.show();


            }
        });

        textView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Calendar calender = Calendar.getInstance();
                current_date = calender.get(Calendar.DAY_OF_MONTH);
                current_month = calender.get(Calendar.MONTH);
                current_year = calender.get(Calendar.YEAR);

                String b_date = date + "/" + month + "/" + year;
                String t_date = current_date + "/" + current_month + "/" + current_year;

                SimpleDateFormat simpleDateFormat = new SimpleDateFormat("dd/MM/yyyy");

                try {
                    Date birth_date = simpleDateFormat.parse(b_date);
                    Date today_date = simpleDateFormat.parse(t_date);

                    long start_date = birth_date.getTime();
                    long end_date = today_date.getTime();

                    if(start_date <= end_date){
                        org.joda.time.Period period = new Period(start_date, end_date, PeriodType.yearMonthDay());
                        years = period.getYears();
                        months = period.getMonths();
                        days = period.getDays();

                        date_tv.setText(String.valueOf(days));
                        month_tv.setText(String.valueOf(months));
                        year_tv.setText(String.valueOf(years));

                        inmonths_tv.setText(String.valueOf((years * 12) + months  ));
                        yinweeks_tv.setText(String.valueOf(((years * 12) + months ) * 4 ));
                        indays_tv.setText(String.valueOf((((years * 12) + months ) * 4) * 7 ));
                    }
                    else{
                        date_tv.setText("Error");
                        month_tv.setText("Error");
                        year_tv.setText("Error");

                        inmonths_tv.setText("Error");
                        yinweeks_tv.setText("Error");
                        indays_tv.setText("Error");

                        Toast.makeText(getApplicationContext(), "Birthday must be smaller than current date", Toast.LENGTH_LONG).show();

                    }

                } catch (ParseException e) {
                    e.printStackTrace();
                }





            }

        });



    }



}