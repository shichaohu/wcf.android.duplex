package com.example.teacher;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import com.example.teacher.home.MainActivity;

import java.util.Calendar;
import java.util.TimeZone;

public class Activity1 extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_1);

        Button btn =(Button) findViewById(R.id.aty_1_btn);
        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                TextView tv=(TextView) findViewById(R.id.aty_1_view);

                final Calendar c = Calendar.getInstance();
                c.setTimeZone(TimeZone.getTimeZone("GMT+8:00"));
                String mYear = String.valueOf(c.get(Calendar.YEAR)); // 获取当前年份

                tv.setText("activity_1触发了点击事件"+ mYear);

                Intent intent=new Intent();
                intent.setClass(Activity1.this,MainActivity.class);
                //intent.setClassName(MainActivity.this,"com.example.teacher.Activity1");
                startActivity(intent);
                overridePendingTransition(R.anim.in_from_left,R.anim.out_to_right);
                Activity1.this.finish();

            }
        });
    }
}
