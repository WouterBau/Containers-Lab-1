export interface WeatherForecast {
    date: Date;
    temperatureC: Number;
    temperatureF: Number;
    summary: string | null;
    lastMessage: string | null;
}