<?php

namespace App;

use Illuminate\Notifications\Notifiable;
use Illuminate\Contracts\Auth\MustVerifyEmail;
use Illuminate\Foundation\Auth\User as Authenticatable;

class User extends Authenticatable
{
    use Notifiable;

    /**
     * The attributes that are mass assignable.
     *
     * @var array
     */
    protected $fillable = [
        'id','email', 'password', 'tipo',
    ];

    /**
     * The attributes that should be hidden for arrays.
     *
     * @var array
     */
    protected $hidden = [
        'password', 'remember_token',
    ];

    public function alumno(){
      return $this->hasOne('App\Alumno');
    }
    public function profesore(){
      return $this->hasOne('App\Profesore');
    }
    public function secretaria(){
      return $this->hasOne('App\Secretaria');
    }
    public function directorcarrera(){
      return $this->hasOne('App\DirectoresCarrera');
    }
}
