package com.company.chatSystem;

import java.util.ArrayList;

/**
 * Created by User on 22/11/2014.
 */
public class MessageBoard implements StringConsumer, StringProducer {

    private ArrayList<StringConsumer> stringConsumers;

    public MessageBoard() {
        this.stringConsumers = new ArrayList<StringConsumer>();
    }

    @Override
    public void consume(String str) {
        for (StringConsumer stringConsumer : stringConsumers)
        {
            stringConsumer.consume(str);
        }
    }

    @Override
    public void addConsumer(StringConsumer sc) {
        stringConsumers.add(sc);
    }

    @Override
    public void removeConsumer(StringConsumer sc) {
        this.stringConsumers.remove(sc);
    }
}
