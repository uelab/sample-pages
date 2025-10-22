---
layout: default
title: People
---

{% assign phd-candidates = site.people | where_exp: "item", "item.role == 'PhD Candidate'" | sort: "graduation-year" %}
{% assign phd-students = site.people | where_exp: "item", "item.role == 'PhD Student'" | sort: "graduation-year" %}
{% assign pi = site.people | where_exp: "item", "item.role == 'Principal Investigator'" %}
{% assign current = pi | concat: phd-candidates | concat: phd-students %}

{% assign alumni = site.people | where_exp : "item", "item.role == 'Alum'" | sort: "graduation-year" | reverse %}

{% include member-grid.html header="People" values=current %}

{% include member-grid.html header="Alumni" values=alumni %}