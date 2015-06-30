package il.ac.hit.currencies

import scala.xml._
import java.net._

class XMLSerializer(path:String,dataUpdater: ICurrencyUpdater) extends Thread {

  //setting the members in the class and updating the data for the first time
  this.setName("XMLSerializer thread")
  var data:CurrenciesDataManager = new CurrenciesDataManager
  var pathToSaveFile:String = path
  var currencyUpdater:ICurrencyUpdater = dataUpdater
  var isFirstTime:Boolean = true
  upToDateData

  override def run {

    while(true)
    {
      upToDateData
      if(!isFirstTime) {
        currencyUpdater.updateCurrencyData(data.listData);
      }
      Thread.sleep(1 * 60 * 1000 * 5)
      isFirstTime = false
    }
  }

  def get = data.listData

  def upToDateData() = {
    var url: URL = null
    var connection: URLConnection = null
    var doc: Elem = null
    var coinName: String = ""
    var country: String = ""
    var rate: Double = 0
    var unit: Int = 0

    //clear the data from the previous update
    data.cleanData(pathToSaveFile)
    //reading the data from the XML file
    try {
      url = new URL("http://www.boi.org.il/currency.xml")
      connection = url.openConnection
      doc = XML.load(connection.getInputStream)
      for (ob <- (doc \\ "CURRENCY")) {
        coinName = (ob \\ "NAME").text
        country = (ob \\ "COUNTRY").text
        rate = ((ob \\ "RATE").text).toDouble
        unit = ((ob \\ "UNIT").text).toInt
        data.listData.add(new Currency(coinName, unit, rate, country))
      }
      data.listData.add(new Currency("NIS", 1, 1, "Israel"))
      data.lastUpdate = (doc \\ "LAST_UPDATE").text
      //writing the update data
      data.writeData(pathToSaveFile)
    }
    catch { case e:Exception => throw new CurrenciesPlatformException(e.getMessage) }
  }

  def getLastUpdate = data.getLastUpdate
}
