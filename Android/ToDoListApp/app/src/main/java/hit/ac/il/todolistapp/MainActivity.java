package hit.ac.il.todolistapp;

import android.app.Activity;
import android.app.AlarmManager;
import android.app.PendingIntent;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.webkit.WebView;
import java.sql.Timestamp;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

/**
 * A MainActivity is a class that represents the screen of the application, </br>
 * extends the Activity class
 */
public class MainActivity extends Activity {

    private WebView webView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        webView = (WebView) findViewById(R.id.webView);
        webView.loadUrl("http://todomanager.j.layershift.co.uk/doitsimple/homepage");
        webView.getSettings().setJavaScriptEnabled(true);
        AlarmSender alarmSender = new AlarmSender();
        webView.addJavascriptInterface(alarmSender, "alarmSenderProp");
        webView.addJavascriptInterface(alarmSender,"alarmDeleteProp");
        webView.addJavascriptInterface(alarmSender,"alarmUpdateProp");
        webView.setWebViewClient(new UrlInterceptor());
    }

    @Override
    protected void onNewIntent(Intent intent) {
        if (intent != null) {
            String time = intent.getStringExtra("time");
            System.out.print(time);
            String name = intent.getStringExtra("name");
            System.out.print(name);
            String description = intent.getStringExtra("description");
            System.out.print(description);
            //load the url for the specific item
            webView.loadUrl("http://todomanager.j.layershift.co.uk/doitsimple/todo_item_manager");
        }
    }

    private static Long ParseDateToTimeStamp(String dateString) {
        Date dateUtil = null;
        java.sql.Date dateSQL = null;
        String dateArray[] = new String[2];
        DateFormat simpleDate = null;
        String format = "yyyy-mm-dd hh:mm:ss";
        if(dateString != null) {
            try {
                if(dateString.contains("T")) {
                    dateArray = dateString.split("T");
                    if(dateArray[1].contains("Z"))
                    {
                        dateArray[1] = dateArray[1].substring(0,dateArray[1].length()-1);
                    }
                    dateString = dateArray[0] + " " + dateArray[1] + ":00";

                }
                else {
                    if(dateString.contains("."))
                    {
                        dateString = dateString.substring(0,dateString.length()-2);
                    }
                    else {
                        dateString += ":00";
                        format = "dd-mm-yyyy hh:mm:ss";
                    }
                }
                simpleDate = new SimpleDateFormat(format);
                System.out.println("String " + dateString);
                System.out.println("util " + simpleDate.parse(dateString));
                dateUtil = simpleDate.parse(dateString);
                dateSQL = new java.sql.Date(dateUtil.getTime());
                dateSQL.setMonth(Integer.parseInt(dateString.split("-")[1])-1);
                System.out.println(dateSQL);
            } catch (ParseException e) {
                e.printStackTrace();
            }
        }
        java.sql.Timestamp timestamp = new Timestamp(dateSQL.getTime());
        return timestamp.getTime();
    }

    /**
     * An AlarmSender is an inner class that is in charge for sending notification to the alarm manager.
     */
    public class AlarmSender {

        /**
         * <p>
         * In order to add notification to the AlarmSender.
         * </p>
         *
         * @param name
         * <code>String</code> - name
         * @param description
         * <code>String</code> - description
         *  @param date
         * <code>String</code> - date
         */
        @android.webkit.JavascriptInterface
        public void addAlarmPerToDoItem(String name, String description, String date) {
            //explicit intent
            long time = ParseDateToTimeStamp(date);
            Intent intent = new Intent(MainActivity.this, NotificationService.class);
            intent.putExtra("name", name);
            intent.putExtra("description", description);
            intent.putExtra("time", time);
            int id = (name + description + time).hashCode();
            intent.setData(Uri.parse(String.valueOf(id)));
            PendingIntent pendingIntent = PendingIntent.getService(MainActivity.this, id, intent, PendingIntent.FLAG_UPDATE_CURRENT);
            AlarmManager alarmManager = (AlarmManager) getSystemService(ALARM_SERVICE);
            alarmManager.set(AlarmManager.RTC_WAKEUP, time, pendingIntent);
        }

        /**
         * <p>
         * In order to delete notification from the AlarmSender.
         * </p>
         *
         * @param name
         * <code>String</code> - name
         * @param description
         * <code>String</code> - description
         *  @param date
         * <code>String</code> - date
         */
        @android.webkit.JavascriptInterface
        public void deleteAlarmPerToDoItem(String name, String description, String date) {
            long time = ParseDateToTimeStamp(date);
            Intent intent = new Intent(MainActivity.this, NotificationService.class);
            intent.putExtra("name", name);
            intent.putExtra("description", description);
            intent.putExtra("time", time);
            int id = (name + description + time).hashCode();
            intent.setData(Uri.parse(String.valueOf(id)));
            PendingIntent pendingIntent = PendingIntent.getService(MainActivity.this, id, intent, PendingIntent.FLAG_UPDATE_CURRENT);
            AlarmManager alarmManager = (AlarmManager) getSystemService(ALARM_SERVICE);
            alarmManager.cancel(pendingIntent);
        }

        /**
         * <p>
         * In order to update notification from the AlarmSender.
         * </p>
         *
         * @param oldName
         * <code>String</code> - old name
         * @param oldDescription
         * <code>String</code> - old description
         *  @param oldDate
         * <code>String</code> - old date
         * @param newName
         * <code>String</code> - new name
         * @param newDescription
         * <code>String</code> - new description
         *  @param newDate
         * <code>String</code> - new date
         */
        @android.webkit.JavascriptInterface
        public void updateAlarmPerToDoItem(String oldName, String oldDescription, String oldDate, String newName, String newDescription, String newDate) {
            long oldTime = ParseDateToTimeStamp(oldDate);
            Intent oldIntent = new Intent(MainActivity.this, NotificationService.class);
            oldIntent.putExtra("name", oldName);
            oldIntent.putExtra("description", oldDescription);
            oldIntent.putExtra("time", oldTime);
            int oldId = (oldName + oldDescription + oldTime).hashCode();
            oldIntent.setData(Uri.parse(String.valueOf(oldId)));
            PendingIntent oldPendingIntent = PendingIntent.getService(MainActivity.this, 0, oldIntent, PendingIntent.FLAG_UPDATE_CURRENT);
            AlarmManager alarmManager = (AlarmManager) getSystemService(ALARM_SERVICE);
            alarmManager.cancel(oldPendingIntent);

            long newTime = ParseDateToTimeStamp(newDate);
            Intent newIntent = new Intent(MainActivity.this, NotificationService.class);
            oldIntent.putExtra("name", newName);
            oldIntent.putExtra("description", newDescription);
            oldIntent.putExtra("time", newTime);
            int newId = (newName + newDescription + newTime).hashCode();
            newIntent.setData(Uri.parse(String.valueOf(newId)));
            PendingIntent newPendingIntent = PendingIntent.getService(MainActivity.this, 0, newIntent, PendingIntent.FLAG_UPDATE_CURRENT);
            alarmManager.set(AlarmManager.RTC_WAKEUP, newTime, newPendingIntent);
        }

    }
}