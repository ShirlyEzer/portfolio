package hit.ac.il.todolistapp;

import android.app.Notification;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.app.Service;
import android.content.Intent;
import android.graphics.Color;
import android.os.IBinder;

/**
 * <p>
 * This is class for notification service. which extends Service, </br>
 * In the onStartCommand a new thread is created for all the service's work.
 * </p>
 *
 * @author Shirly Ezer
 * @author Oreyan Or
 */
public class NotificationService extends Service {

    /**
     * <p>
     * Class Constructor [Empty]. Create new NotificationService.
     * </p>
     */
    public NotificationService() {
    }

    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }

    @Override
    public int onStartCommand(final Intent intent, int flags, int startId) {
        Runnable runnable = new Runnable() {
            @Override
            public void run() {
                if(intent!=null) {
                    String time = intent.getStringExtra("time");
                    String name = intent.getStringExtra("name");
                    String description = intent.getStringExtra("description");
                    //Explicit intent
                    Intent mainIntent = new Intent(NotificationService.this, MainActivity.class);
                    mainIntent.putExtra("time", time);
                    mainIntent.putExtra("name", name);
                    mainIntent.putExtra("description", description);

                    PendingIntent pendingIntent = PendingIntent.getActivity(NotificationService.this, 0, mainIntent, PendingIntent.FLAG_UPDATE_CURRENT);
                    Notification notification = new Notification.Builder(NotificationService.this)
                            .setContentIntent(pendingIntent)
                            .setSmallIcon(R.mipmap.ic_launcher)
                            .setLights(Color.BLUE,3,5)
                            .setContentText(name)
                            .setContentTitle(description)
                            .setAutoCancel(true)
                            .build();

                    NotificationManager notificationManager = (NotificationManager) getSystemService(NOTIFICATION_SERVICE);
                    notificationManager.notify(name.hashCode(), notification);

                }
                //stop this service
                stopSelf();
            }
        };
        Thread thread = new Thread(runnable);
        thread.start();

        return super.onStartCommand(intent,flags,startId);
    }
}
