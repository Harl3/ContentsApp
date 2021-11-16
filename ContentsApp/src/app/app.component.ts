import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public contents?: Contents;
  dtOptions: DataTables.Settings = {};
  lSettings: DataTables.LanguageSettings = { searchPlaceholder: "Cerca per titolo", search: "" };
  unauthorized: boolean = false;

  constructor(http: HttpClient) {
    http.get<Contents>('/contents', {
      headers: { 'X-Api-Key': 'C5BFF7F0-B4DF-475E-A331-F737424F013C' }
    }).subscribe(result => {
      this.contents = result;
    }, error => {
      console.error(error);
      this.unauthorized = error.status === 401;
    });
    this.dtOptions = {
      paging: false,
      order: [[3, "desc"]],
      columnDefs: [
        {
          "targets": 1,
          "searchable": false
        },
        {
          "targets": 2,
          "searchable": false
        },
        {
          "targets": 3,
          "searchable": false
        },
        {
          "targets": 4,
          "searchable": false
        },
        {
          "targets": 5,
          "searchable": false
        },
        {
          "targets": 6,
          "searchable": false
        },
        {
          "targets": 7,
          "searchable": false
        },
        {
          "targets": 8,
          "searchable": false
        },
        {
          "targets": 9,
          "searchable": false
        },
        {
          "targets": 10,
          "searchable": false
        }],
      language: this.lSettings
    };
  }

  title = 'ContentsApp';

  applyFilter(event: any) {
    console.log(event.target.value);
    if (this.contents) {
      let filtered = this.contents.data.contents.filter(x => x.title.toLowerCase().includes(event.target.value));
      console.log(filtered);
    }
  }
}

interface Content {
  liveStatusOnAir: boolean;
  liveStatusRecording: boolean;
  onDemandFileName: string;
  onDemandEncodingDescription: string;
  onDemandDuration: string;
  gidEncodingProfileOnDemand: string;
  liveMultibitrate: boolean;
  title: string;
  trash: boolean;
  hasPoster: boolean;
  onDemandEncodingStatus: number;
  gidProperty: string;
  contentId: string;
  contentType: number;
  deliveryStatus: number;
  protectedEmbed: boolean;
  creationDate: Date;
  updateDate: Date;
  publishDateUTC: Date;
  publishStatus: number;
}

interface ContentCount {
  totalContents: number;
  onDemandVideoCount: number;
  onDemandAudioCount: number;
  liveEventVideoCount: number;
  liveEventAudioCount: number;
  playlistCount: number;
  originCount: number;
  folderCount: number;
}

interface Data {
  folders: any[];
  contents: Content[];
  returnedContents: number;
  returnedFolders: number;
  contentCount: ContentCount;
}

interface Contents {
  code: number;
  status: string;
  isSuccessStatusCode: boolean;
  data: Data;
}
