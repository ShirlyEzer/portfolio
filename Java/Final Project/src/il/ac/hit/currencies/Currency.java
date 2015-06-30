package il.ac.hit.currencies;

import java.io.Serializable;

/**
 * <code>Currency</code> represents a currency
 *
 * @author Oreyan&Shirly
 */
public class Currency implements Serializable {

    /**
     * @param coinName - String for currency coin name
     * @param unit - int for currency unit
     * @param rate - double for currency rate
     * @param country - String for currency country
     **/
    private String coinName;
    private int unit;
    private double rate;
    private String country;

    /**
     * Create new <code>Currency</code>
     */
    public Currency(String coinName, int unit, double rate, String country) {
        setCoinName(coinName);
        setUnit(unit);
        setRate(rate);
        setCountry(country);
    }

    /**
     * Sets the coin's name of a currency.
     *
     * @param coinName - The coin name
     */
    public void setCoinName(String coinName) {
        this.coinName = coinName;
    }

    /**
     * Sets the coin's unit of a currency.
     *
     * @param unit - The coin unit
     */
    public void setUnit(int unit) {
        this.unit = unit;
    }

    /**
     * Sets the coin's country of a currency.
     *
     * @param country - The coin country
     */
    public void setCountry(String country) {
        this.country = country;
    }

    /**
     * Sets the coin's rate of a currency.
     *
     * @param rate - The coin rate
     */
    public void setRate(double rate) {
        this.rate = rate;
    }

    /**
     * This Method returns the coin's name of a currency.
     */
    public String getCoinName() {
        return coinName;
    }

    /**
     * This Method returns the coin's unit.
     */
    public int getUnit() {
        return unit;
    }

    /**
     * This Method returns the coin's rate.
     */
    public double getRate() {
        return rate;
    }

    /**
     * This Method returns the coin's country.
     */
    public String getCountry() {
        return country;
    }
}
