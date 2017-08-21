package com.example.teacher.home;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import com.example.teacher.Activity1;
import com.example.teacher.R;

import java.util.Calendar;
import java.util.TimeZone;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        //setContentView(R.layout.activity_main);`

        //requestWindowFeature(Window.FEATURE_CUSTOM_TITLE);
        setContentView(R.layout.activity_main);
        

        Button btn =(Button) findViewById(R.id.aty_main_btn);
        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                TextView tv=(TextView) findViewById(R.id.aty_main_view);

                final Calendar c = Calendar.getInstance();
                c.setTimeZone(TimeZone.getTimeZone("GMT+8:00"));
                String mYear = String.valueOf(c.get(Calendar.SECOND)); // 获取当前年份

                tv.setText("activity_main触发了点击事件"+ mYear);
                Intent intent=new Intent();
                intent.setClass(MainActivity.this,Activity1.class);
                //intent.setClassName(MainActivity.this,"com.example.teacher.Activity1");
                startActivity(intent);
                overridePendingTransition(R.anim.dync_in_from_right,R.anim.dync_out_to_left);

                //MainActivity.this.finish();
            }
        });
    }
}
