<?php

namespace App;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Notifications\Notifiable;
use Illuminate\Foundation\Auth\User as Authenticatable;

class User extends Authenticatable
{
  use Notifiable;

  /**
   * @var  array
   */

  protected $fillable =['id', 'nombre', 'dpto', 'password'];

  /**
   * @var  array
   */

  protected $hidden = ['password', 'remember_token'];


  public function pedidos()
  {
    return $this->hasMany(Pedido::class, 'user_id', 'id');
  }

}
