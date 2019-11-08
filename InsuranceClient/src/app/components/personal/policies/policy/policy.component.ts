import { Component, OnInit, Input } from '@angular/core';
import { Policy } from 'src/app/models/policy';

@Component({
  selector: 'app-policy',
  templateUrl: './policy.component.html',
  styleUrls: ['./policy.component.scss']
})
export class PolicyComponent implements OnInit{

  ngOnInit(){
  }

  endPolicyDate: Date = new Date();

    @Input() policy: Policy;
}
