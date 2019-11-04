import { Component, OnInit } from '@angular/core';
import { PolicyService } from 'src/app/services/policy.service';
import { EmailValidator } from '@angular/forms';

@Component({
  selector: 'app-policies',
  templateUrl: './policies.component.html',
  styleUrls: ['./policies.component.scss']
})
export class PoliciesComponent implements OnInit {

  constructor(private policyService: PolicyService) { }

  policies: any;

  ngOnInit() {
    var email = localStorage.getItem('email');
    this.policyService.getPolicies(email).subscribe((data: any) => {
      this.policies = data;
      console.log(this.policies);
    })
  }
}
