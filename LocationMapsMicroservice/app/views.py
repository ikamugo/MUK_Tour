"""
Definition of views.
"""

from datetime import datetime
from django.shortcuts import render
from django.http import HttpRequest,JsonResponse, HttpResponse

import requests

from . models import Place


def search_view(request):
    # response = requests.get('https://places.ls.hereapi.com/places/v1/autosuggest?at=40.74917,-73.98529&q=chrysler&apiKey=SagftoH9j5tk5u241lXnUAxPHDR_QtRIU1l0LYJO3No')
    try:
        location = request.GET['name']
        if not location:
            raise ValueError("EMPTY QUERY")
    except Exception as e:
        return HttpResponse('BAD_REQUEST: Query parameter name is required.',status=400)
    
    response = requests.get("https://autocomplete.search.hereapi.com/v1/autocomplete?q=" + location + "&apiKey=SagftoH9j5tk5u241lXnUAxPHDR_QtRIU1l0LYJO3No")
    places = response.json()['items']
    search = []
    for item in places:
        search.append({
            "title":item['title'],
            "id": item['id'],
            "country": item['address']['countryName'],
            "city": item['address']['city'],
            }) 
    return JsonResponse({ "places": search })

def location_view(request):
    location_place = request.GET['name']
    response = requests.get("https://geocode.search.hereapi.com/v1/geocode?q=" + location_place +"&apiKey=SagftoH9j5tk5u241lXnUAxPHDR_QtRIU1l0LYJO3No")

    search_result = response.json()['items']
    result = []
    for item in search_result:
        result.append({
            "title": item['title'],
            "resultType":item['resultType'],
            "localityType": item['localityType'],
            "position":item['position'],
            "mapView": item['mapView']

            })
        place = Place(name=item['title'], position=str(item['position']['lat'])+","+str(item['position']['lng']))
        place.save()

    return JsonResponse({"search": result })

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
