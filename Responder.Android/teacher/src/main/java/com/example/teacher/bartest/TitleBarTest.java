package com.example.teacher.bartest;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.widget.Toast;

import com.example.teacher.R;

import common.CustomTitleBar;

public class TitleBarTest extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_title_bar_test);


        CustomTitleBar customTitleBar = (CustomTitleBar) findViewById(R.id.tb_title);
        customTitleBar.setOnTitleClickListener(new CustomTitleBar.TitleOnClickListener() {
            @Override
            public void onLeftClick() {
                Toast.makeText(TitleBarTest.this, "点击了左边的返回按钮", Toast.LENGTH_SHORT).show();
            }

            @Override
            public void onRightClick() {
                Toast.makeText(TitleBarTest.this, "点击了右边的保存按钮", Toast.LENGTH_SHORT).show();
            }
        });
    }

}
