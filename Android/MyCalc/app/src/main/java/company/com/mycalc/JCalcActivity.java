package company.com.mycalc;

import android.app.Activity;
import android.widget.*;
import android.os.Bundle;
import android.view.View.*;
import android.view.*;

public class JCalcActivity extends Activity
{
    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        final Button btPlus = (Button)this.findViewById(R.id.bt_plus);
        final Button btMinus = (Button)this.findViewById(R.id.bt_minus);
        final Button btMultiply = (Button)this.findViewById(R.id.bt_multiply);
        final Button btDivide = (Button)this.findViewById(R.id.bt_divide);
        final Button btModulo = (Button)this.findViewById(R.id.bt_modulo);
        OnClickListener btListener = new OnClickListener()
        {
            public void onClick(View view)
            {
                double firstNum = 0, secondNum = 0;
                try {
                    firstNum = Double.parseDouble(((EditText) JCalcActivity.this.findViewById(R.id.EditText01)).getText().toString());
                    secondNum = Double.parseDouble(((EditText) JCalcActivity.this.findViewById(R.id.EditText02)).getText().toString());
                }
                catch (NumberFormatException e) {
                    if(((EditText) JCalcActivity.this.findViewById(R.id.EditText01)).getText().toString() == null)
                        firstNum = 0;
                    if(((EditText) JCalcActivity.this.findViewById(R.id.EditText02)).getText().toString() == null)
                        secondNum = 0;
                }
                double result = 0;
                if(view==btPlus)
                {
                    result = firstNum + secondNum;
                }
                else if(view==btMinus)
                {
                    result = firstNum - secondNum;
                }
                else if(view==btMultiply)
                {
                    result = firstNum * secondNum;
                }
                else if(view==btDivide)
                {
                    if (secondNum != 0)
                        result = firstNum / secondNum;
                    else result = 0;
                }
                else if(view==btModulo)
                {
                    if (secondNum != 0)
                        result = firstNum % secondNum;
                    else result = 0;
                }
                EditText text = ((EditText)JCalcActivity.this.findViewById(R.id.EditText03));
                text.setText(""+result);
            }
        };
        btPlus.setOnClickListener(btListener);
        btMinus.setOnClickListener(btListener);
        btMultiply.setOnClickListener(btListener);
    }
}
