export interface WeatherForecast {
  date: string;
  forecastWeather: ForecastConditions;
  astro: Astro;
  hourly: HourlyForecast[];
}

export interface HourlyForecast {
  time: string;
  willItRain: boolean;
  chanceOfRain: string;
  temperature: number;
  isDay: boolean;
  condition: Condition;
  windSpeed: number;
  windDirection: string;
  windDegrees: number;
  windGust: number;
  pressure: number;
  precipitation: number;
  humidity: number;
  cloud: number;
  feelsLike: number;
  visibility: number;
  uvIndex: number;
}

export interface Astro {
  sunrise: string;
  sunset: string;
  moonrise: string;
  moonSet: string;
}

export interface ForecastConditions {
  high: number;
  low: number;
  temperature: number;
  windSpeed: number;
  precipitation: number;
  visibility: number;
  humidity: number;
  willItRain: boolean;
  chanceOfRain: string;
  uvIndex: number;
  condition: Condition;
}

export interface Condition {
  text: string;
  icon: string;
  code: number;
}
