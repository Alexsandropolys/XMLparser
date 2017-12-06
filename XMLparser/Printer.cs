using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMLparser
{
    class Printer
    {

        public void InitMap(GMapControl gMapCon, double LatInit, double LongInit, string MapName)
        {
            gMapCon.Overlays.Clear();
            gMapCon.DragButton = MouseButtons.Left;
            gMapCon.CanDragMap = true;
            switch (MapName)
            {
                case "Arcgis_Topo_Map": { gMapCon.MapProvider = GMapProviders.ArcGIS_World_Topo_Map; }
                    break;
                case "Google_Satellite":
                    { gMapCon.MapProvider = GMapProviders.GoogleSatelliteMap; }
                    break;
                case "Google_Map":
                    { gMapCon.MapProvider = GMapProviders.GoogleMap; }
                    break;
                case "Yandex_Map":
                    { gMapCon.MapProvider = GMapProviders.YandexMap; }
                    break;
            }

            
            gMapCon.Position = new PointLatLng(LatInit, LongInit);
            gMapCon.MinZoom = 0;
            gMapCon.MaxZoom = 24;
            gMapCon.Zoom = 16;
            gMapCon.AutoScroll = true;
        }

        public void showSafeZone(GMapControl gMapCon, Color clr, SafeZone sz)
        {
            
            GMapOverlay polygons = new GMapOverlay("polygons");
            List<PointLatLng> points = new List<PointLatLng>();

            foreach (Dot dt in sz.dots)
            {
                points.Add(new PointLatLng(dt.x, dt.y));
            }

            GMapPolygon polygon = new GMapPolygon(points, "safeZone");

            polygon.Fill = new SolidBrush(Color.FromArgb(50, clr));
            polygon.Stroke = new Pen(clr, 1);
            polygons.Polygons.Add(polygon);
            polygon.IsHitTestVisible = true;
            gMapCon.Overlays.Add(polygons);
        }

        public void showParcel(GMapControl gMapCon, Color clr, Parcel  pl)
        {
            if (pl.isCrossed)
            {
                clr = Color.Red;
            }
            GMapOverlay polygons = new GMapOverlay("safeZones");
            List<PointLatLng> points = new List<PointLatLng>();

            foreach (Dot dt in pl.dots)
            {
                points.Add(new PointLatLng(dt.Lat, dt.Long));
            }

            GMapPolygon polygon = new GMapPolygon(points, pl.cadastralNumber);

            polygon.Fill = new SolidBrush(Color.FromArgb(50, clr));
            polygon.Stroke = new Pen(clr, 1);
            polygon.IsHitTestVisible = true;
            polygons.Polygons.Add(polygon);
            gMapCon.Overlays.Add(polygons);
        }

        public void showParcels(GMapControl gMapCon, Color clr, List<Parcel> pl)
        {
            foreach (Parcel prs in pl)
            {
                this.showParcel(gMapCon, clr, prs);
            }
        }
    }
}
