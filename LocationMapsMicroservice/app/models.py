"""
Definition of models.
"""

from django.db import models

class Place(models.Model):
	name = models.CharField(max_length=200, null=True, blank=True)
	position = models.CharField(max_length=200, null=True, blank=True)

	def __str__(self):
		return self.name + " " + self.position