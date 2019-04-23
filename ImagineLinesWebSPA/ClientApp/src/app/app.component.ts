import { Component, OnInit } from '@angular/core';
import { ConfigurationService } from '../shared/services/configuration.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(private configurationService: ConfigurationService) { }

  ngOnInit(): void {
    this.configurationService.load();
  }
}
