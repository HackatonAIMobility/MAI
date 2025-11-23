// openStreetMap.js
let maps = {};
let markers = {};
let polylines = {};
let dotnetHelpers = {};

export function initializeMap(options, dotnetHelper) {
    // Store the dotnetHelper reference
    dotnetHelpers[options.mapId] = dotnetHelper;

    // Create the map
    const map = L.map(options.mapId).setView([options.center.lat, options.center.lng], options.zoom);

    // Add the OpenStreetMap tiles
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);

    // Add click handler to map
    map.on('click', async function(e) {
        await dotnetHelper.invokeMethodAsync('OnMapClickFromJS', e.latlng.lat, e.latlng.lng);
    });
    map.invalidateSize();
    // Store the map reference
    maps[options.mapId] = map;
    markers[options.mapId] = {};
    polylines[options.mapId] = [];

    // Add initial markers if they exist
    if (options.markers && options.markers.length > 0) {
        options.markers.forEach(marker => {
            addMarker(options.mapId, marker);
        });
    }

    return map;
}

export function setMapCenter(mapId, latitude, longitude, zoom) {
    const map = maps[mapId];
    if (map) {
        map.setView([latitude, longitude], zoom);
    }
}

export function addMarker(mapId, markerData) {
    const map = maps[mapId];
    if (!map) return;

    let markerIcon = null;
    if (markerData.iconSvg) {
        const svgIcon = L.divIcon({
            html: markerData.iconSvg,
            className: 'custom-marker-icon',
            iconSize: markerData.iconSize || [32, 32],
            iconAnchor: markerData.iconAnchor || [16, 32]
        });
        markerIcon = svgIcon;
    }

    // Create marker with optional custom icon
    const marker = L.marker(
        [markerData.latitude, markerData.longitude], 
        markerIcon ? { icon: markerIcon } : {}
    ).bindPopup(markerData.title).addTo(map);

    // Add click handler to marker
    marker.on('click', async function() {
        const dotnetHelper = dotnetHelpers[mapId];
        if (dotnetHelper) {
            await dotnetHelper.invokeMethodAsync('OnMarkerClickedFromJS', {
                id: markerData.id,
                latitude: markerData.latitude,
                longitude: markerData.longitude,
                title: markerData.title
            });
        }
    });

    // Store the marker reference
    markers[mapId][markerData.id] = marker;

    return marker;
}

export function removeMarker(mapId, markerId) {
    const map = maps[mapId];
    const marker = markers[mapId][markerId];
    
    if (map && marker) {
        map.removeLayer(marker);
        delete markers[mapId][markerId];
    }
}

export function clearMarkers(mapId) {
    const mapMarkers = markers[mapId];
    if (mapMarkers) {
        Object.values(mapMarkers).forEach(marker => {
            maps[mapId].removeLayer(marker);
        });
        markers[mapId] = {};
    }
}

export function updateMarker(mapId, markerData) {
    // Remove existing marker if it exists
    removeMarker(mapId, markerData.id);
    // Add the updated marker
    addMarker(mapId, markerData);
}

export function refreshMap(mapId) {
    const map = maps[mapId];
    if (map) {
        // Invalidate size and reset view to trigger proper rendering
        map.invalidateSize(true);
        return true;
    }
    return false;
}

export function drawPolyline(mapId, coordinates) {
    const map = maps[mapId];
    if (map) {
        const polyline = L.polyline(coordinates, { color: 'blue' }).addTo(map);
        polylines[mapId].push(polyline);
        map.fitBounds(polyline.getBounds());
    }
}

export function clearPolylines(mapId) {
    const map = maps[mapId];
    if (map && polylines[mapId]) {
        polylines[mapId].forEach(polyline => {
            map.removeLayer(polyline);
        });
        polylines[mapId] = [];
    }
}