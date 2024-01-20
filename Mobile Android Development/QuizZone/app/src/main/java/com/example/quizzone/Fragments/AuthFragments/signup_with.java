package com.example.quizzone.Fragments.AuthFragments;

import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;

import com.example.quizzone.R;

public class signup_with extends Fragment {


    TextView btn;
    Button BtnAuth;

    public signup_with() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_signup_with, container, false);

        btn = view.findViewById(R.id.tv_btn_auth);

        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                login_with loginWith = new login_with();
                FragmentManager fragmentManager = getFragmentManager();
                FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
                fragmentTransaction.hide(signup_with.this);
                fragmentTransaction.add(R.id.fragment_viewer, loginWith);
                fragmentTransaction.commit();
            }
        });

        BtnAuth = view.findViewById(R.id.btn_auth);
        BtnAuth.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Signup_with_email SignUnWithEmail = new Signup_with_email();
                FragmentManager fragmentManager = getFragmentManager();
                FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
                fragmentTransaction.hide(signup_with.this);
                fragmentTransaction.add(R.id.AuthActivity, SignUnWithEmail);
                fragmentTransaction.commit();
            }
        });

        return view;
    }
}