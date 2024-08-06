import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../core/services/api.service';
import { Country } from 'src/app/core/models/Country';
import { Router } from '@angular/router';

@Component({
  selector: 'app-step2',
  templateUrl: './step2.component.html',
  styleUrls: ['./step2.component.css']
})
export class Step2Component implements OnInit {
  form: FormGroup;
  countries: Country[] = [];
  provinces: any[] = [];

  constructor(private fb: FormBuilder, private apiService: ApiService, private router: Router) {
    this.form = this.fb.group({
      country: ['', Validators.required],
      province: ['', Validators.required]
    });
  }

  //constructor(private fb: FormBuilder, private apiService: ApiService, private router: Router) {
  //  this.form = this.fb.group({
  //    country: ['', Validators.required],
  //    province: ['', Validators.required],
  //    email: ['', [Validators.required, Validators.email]],
  //    password: ['', Validators.required],
  //    confirmPassword: ['', Validators.required],
  //    isAgree: [false, Validators.requiredTrue]
  //  });
  //}

  ngOnInit() {
    this.apiService.getCountries().subscribe({
      next: (data) => {
        this.countries = this.transformData(data);
        console.log("Processed countries:", this.countries);
      },
      error: (err) => {
        console.error("Error fetching countries:", err);
      }
    });

    const navigation = this.router.getCurrentNavigation();
    const state = navigation?.extras?.state as { user: any };
    //if (!state?.user) {
    //  this.router.navigate(['/step1']);
    //}
  }

  transformData(data: any): Country[] {
    if (!data || !data.$values) {
      console.error('Unexpected data format', data);
      return [];
    }

    const countries = data.$values.map((country: any) => ({
      id: country.id,
      name: country.name,
      provinces: country.provinces.$values.map((province: any) => ({
        id: province.id,
        name: province.name,
        countryId: province.countryId
      }))
    }));
    return countries;
  }


  onCountryChange() {
    const countryId = this.form.get('country')?.value;
    if (countryId) {
      this.apiService.getCountry(countryId).subscribe(data => {
        this.provinces = this.transformProvinces(data.provinces);
      });
    }
  }

  save() {
    if (this.form.valid) {
      const user = {
        email: history.state.user.email,
        password: history.state.user.password,
        confirmPassword: history.state.user.confirmPassword,
        //isAgree: history.state.user.isAgree,
        countryId: parseInt(this.form.value.country),
        provinceId: parseInt(this.form.value.province)
      };

      this.apiService.registerUser(user).subscribe({
        next: () => this.router.navigate(['/success']),
        error: err => console.error('Registration failed', err)
      });
    }
  }

  transformProvinces(data: any): any[] {
    if (!data || !data.$values) {
      console.error('Unexpected data format', data);
      return [];
    }
    const provinces = data.$values.map((province: any) => ({
      id: province.id,
      name: province.name,
      countryId: province.countryId
    }));
    return provinces;
  }

}
