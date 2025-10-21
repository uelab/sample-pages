---
layout: default
title: People
---

{% assign alumni = site.people | where_exp : "item", "item.role == "Alum" %}
{% assign current = site.people | where_exp : "item", "item.role != "Alum" %}

{% include member-grid.html header="People" values=site.current %}

{% include member-grid.html header="Alumni" values=site.alumni %}