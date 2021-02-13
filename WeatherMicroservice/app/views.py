"""
Definition of views.
"""
from datetime import datetime
from django.shortcuts import render
from django.http import HttpRequest, JsonResponse, HttpResponse

import requests


def current_weather_view(request):
    location = request.GET['location']
    response = requests.get("http://api.weatherapi.com/v1/current.json?key=f1071348d50a48b7960125830212101&q="+ location)
    current_weather = response.json()['current']
    result = {
        'temperature':current_weather['temp_c'],
        'isDay':current_weather['is_day'],
        'condition':current_weather['condition'],
        'windSpeed':current_weather['wind_kph'],
        'windDirection':current_weather['wind_degree'],
        'windGust':current_weather['gust_kph'],
        'pressure':current_weather['pressure_mb'],
        'precipitation': current_weather['precip_mm'],
        'humidity':current_weather['humidity'],
        'cloud':current_weather['cloud'],
        'visibility':current_weather['vis_km'],
        'uvIndex': current_weather['uv'],
        'feelsLike':current_weather['feelslike_c'],
    }
    
    return JsonResponse(result)

def forecast_view(request):
    location = request.GET['location']
    response = requests.get("http://api.weatherapi.com/v1/forecast.json?key=f1071348d50a48b7960125830212101&days=3&q="+ location)
    forecast_weather = response.json()['forecast']['forecastday']
    result =[]

    for forecast in forecast_weather:
        result.append({
            'forecastWeather':{
                'high': forecast['day']['maxtemp_c'],
                'low': forecast['day']['mintemp_c'],
                'temperature': forecast['day']['avgtemp_c'],
                'windSpeed': forecast['day']['maxwind_kph'],
                'precipitation': forecast['day']['totalprecip_mm'],
                'visibility': forecast['day']['avgvis_km'],
                'humidity':forecast['day']['avghumidity'],
                'willItRain': forecast['day']['daily_will_it_rain'],
                'chanceOfRain':forecast['day']['daily_chance_of_rain'],
                'uvIndex':forecast['day']['uv'],
                'conditon':forecast['day']['condition'],
            },
            'astro':forecast['astro'],
            'hourly':get_hourly_forecast(forecast['hour']),
            'date':forecast['date'],
        })

    return JsonResponse({'result':result})

def get_hourly_forecast(forecastArray):
    result = []
    for item in forecastArray:
        result.append({
        'temperature':item['temp_c'],
        'isDay':item['is_day'],
        'condition':item['condition'],
        'windSpeed':item['wind_kph'],
        'windDirection':item['wind_degree'],
        'windGust':item['gust_kph'],
        'pressure':item['pressure_mb'],
        'precipitation': item['precip_mm'],
        'humidity':item['humidity'],
        'cloud':item['cloud'],
        'visibility':item['vis_km'],
        'feelsLike':item['feelslike_c'],
        'time':item['time'],
        'willItRain': item['will_it_rain'],
        'chanceOfRain':item['chance_of_rain'],
    })
    return result 

def home(request):
    """Renders the home page."""
    assert isinstance(request, HttpRequest)
    return render(
        request,
        'app/index.html',
        {
            'title':'Home Page',
            'year':datetime.now().year,
        }
    )

def contact(request):
    """Renders the contact page."""
    assert isinstance(request, HttpRequest)
    return render(
        request,
        'app/contact.html',
        {
            'title':'Contact',
            'message':'Your contact page.',
            'year':datetime.now().year,
        }
    )

def about(request):
    """Renders the about page."""
    assert isinstance(request, HttpRequest)
    return render(
        request,
        'app/about.html',
        {
            'title':'About',
            'message':'Your application description page.',
            'year':datetime.now().year,
        }
    )
