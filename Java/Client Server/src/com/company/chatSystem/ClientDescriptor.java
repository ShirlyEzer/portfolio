package com.company.chatSystem;

/**
 * Created by User on 22/11/2014.
 */
public class ClientDescriptor implements StringConsumer,StringProducer {

    private StringConsumer consumer;
    private String nickName;

    public void setNickName(String nickName) {
        this.nickName = nickName;
    }

    public ClientDescriptor(){
        this.consumer = null;
        nickName = null;

    }

    @Override
    public void consume(String str) {
        if (nickName != null)
        {
            consumer.consume(nickName + " : " + str);
        }
        else
        {
            nickName = str;
            consumer.consume(str + " is connected");
        }
    }

    @Override
    public void addConsumer(StringConsumer sc) {
        this.consumer = sc;
    }

    @Override
    public void removeConsumer(StringConsumer sc) {
        if (this.consumer != null)
        {
            this.consumer.consume(nickName + " is disconnected");  // sending message that the client left
            ((StringProducer)this.consumer).removeConsumer(sc);
        }
    }
}
