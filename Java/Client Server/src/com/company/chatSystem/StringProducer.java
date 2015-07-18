package com.company.chatSystem;

/**
 * Created by User on 22/11/2014.
 */
public interface StringProducer {
    public void addConsumer(StringConsumer sc);
    public void removeConsumer(StringConsumer sc);}
