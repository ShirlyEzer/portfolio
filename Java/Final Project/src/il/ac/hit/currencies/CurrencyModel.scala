package il.ac.hit.currencies

import java.io._

class CurrencyModel(dataUpdater: ICurrencyUpdater) extends ICurrencyModel{

  //setting the members in the class and starting the thread who update the text file
  var xmlSerializer:XMLSerializer = new XMLSerializer("./CurrenciesData.txt",dataUpdater)
  xmlSerializer.start

  override def getCurrenciesData : java.util.List[Currency] =
  {
    var dataOfCurrencies:java.util.List[Currency] = null
    var objectInputStream:ObjectInputStream = null
    var fileInputStream:FileInputStream = null

    //reading the update data object from the text file
    try
    {
      fileInputStream = new FileInputStream("./CurrenciesData.txt")
      objectInputStream = new ObjectInputStream(fileInputStream)
      dataOfCurrencies = objectInputStream.readObject().asInstanceOf[java.util.List[Currency]]
    } catch {
      case e:FileNotFoundException => throw new CurrenciesPlatformException(e.getMessage + "file not found")
      case e:IOException => throw new CurrenciesPlatformException(e.getMessage + "could not read object")
      case e:ClassNotFoundException => throw new CurrenciesPlatformException(e.getMessage + "could not cast")
    }
    finally
    {
      if (fileInputStream != null)
        fileInputStream.close()
      if (objectInputStream != null)
        objectInputStream.close()
    }
    dataOfCurrencies
  }

  override def convert(sum: Double, sourceCoin: String, destinationCoin: String) =
  {
    val source: Currency = getCurrency(sourceCoin)
    val destination: Currency = getCurrency(destinationCoin)
    var msg:String = null

    //checking if one or both of the currencies are not found
    if(source == null && destination == null)
    {
      msg = "Currencies not found"
    }
    else {
      if (source == null)
      {
        msg = "Currency " + sourceCoin + " not found"
      }
      if (destination == null)
      {
        msg = "Currency " + destinationCoin + " not found"
      }
    }

    if (msg != null)
      throw new CurrenciesPlatformException(msg)

    sum * (source.getRate * source.getUnit / destination.getRate * destination.getUnit)
  }

  private def getCurrency(coin: String) : Currency = {
    var currencyToReturn: Currency = null
    var currentCoin:String = null
    val vec:java.util.List[Currency] = getCurrenciesData
    var i:Int = 0

    //scanning the list in order to find the specified currency
    while(i<vec.size())
    {
      currentCoin = vec.get(i).getCoinName + " " + vec.get(i).getCountry
      if (currentCoin.equals(coin))
      {
        currencyToReturn = new Currency(vec.get(i).getCoinName,vec.get(i).getUnit,vec.get(i).getRate,vec.get(i).getCountry)
      }
      i = i + 1
    }
    currencyToReturn
  }

  def getLastUpdate = xmlSerializer.getLastUpdate
}
